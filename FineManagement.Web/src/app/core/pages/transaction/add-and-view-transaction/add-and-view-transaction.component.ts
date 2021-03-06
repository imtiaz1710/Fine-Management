import { lastValueFrom } from 'rxjs';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Team } from 'src/app/core/models/team';
import { Transaction } from 'src/app/core/models/transaction';
import { User } from 'src/app/core/models/user';
import { UserTeam } from 'src/app/core/models/user-team';
import { MyProfileService } from 'src/app/core/services/my-profile.service';
import { TeamService } from 'src/app/core/services/team.service';
import { TransactionService } from 'src/app/core/services/transaction.service';
import { UserTeamService } from 'src/app/core/services/user-team.service';
import { UserService } from 'src/app/core/services/user.service';
@Component({
  selector: 'app-add-and-view-transaction',
  templateUrl: './add-and-view-transaction.component.html',
  styleUrls: ['./add-and-view-transaction.component.scss'],
})
export class AddAndViewTransactionComponent implements OnInit {
  addTransactionForm: FormGroup;
  editTransactionForm: FormGroup;
  modalRef: BsModalRef;
  users: User[];
  teams: Team[];
  userTeams: UserTeam[];
  myTeams: Team[];
  usersOfmySelectedTeam: User[];
  transactions: Transaction[];
  filteredTransactions: Transaction[] = [];
  rows = [];

  constructor(
    private modalService: BsModalService,
    private teamService: TeamService,
    private userService: UserService,
    private userTeamService: UserTeamService,
    private toastrService: ToastrService,
    private myProfileService: MyProfileService,
    private formBuilder: FormBuilder,
    private transactionService: TransactionService
  ) {}

  async ngOnInit() {
    this.addTransactionForm = this.formBuilder.group({
      teamId: [''],
      userId: [''],
      amount: [''],
      date: [''],
      note: [''],
    });

    await this.loadAllDataForTrasactionTable();
  }

  private async loadAllDataForTrasactionTable() {
    const transactions$ = this.transactionService.getAllTransactions();
    const users$ = this.userService.getAllUsers();
    const teams$ = this.teamService.getAllTeams();
    const userTeams$ = this.userTeamService.getAllUserTeams();

    this.transactions = await lastValueFrom(transactions$);
    this.users = await lastValueFrom(users$);
    this.teams = await lastValueFrom(teams$);
    this.userTeams = await lastValueFrom(userTeams$);
    this.myTeams = await this.myProfileService.getMyActiveTeamsAsync();

    this.filteredTransactions = [];
    this.loadTransactionList();
    this.rows = this.formateFineList();
  }

  private loadTransactionList() {
    this.myTeams.forEach((myTeam) => {
      let userTeams = this.userTeams.filter((ut) => myTeam.id == ut.teamId);

      userTeams.forEach((ut) => {
        let transaction = this.transactions.filter(
          (tn) => tn.userTeamId == ut.id
        );

        if (!!transaction) this.filteredTransactions.push(...transaction);
      });
    });
  }

  private formateFineList() {
    return this.filteredTransactions.map((fl) => {
      let userTeam = this.userTeams.find((ut) => ut.id == fl.userTeamId);
      let user = this.users.find((u) => u.id == userTeam.userId);
      let team = this.teams.find((t) => t.id == userTeam.teamId);

      return {
        name: user.name,
        teamName: team.name,
        amount: fl.amount,
        date: fl.date,
        note: fl.note,
        id: fl.id,
      };
    });
  }

  edit(id: number) {
    let transaction = this.transactions.find((t) => t.id == id);

    transaction.amount = this.editTransactionForm.value.amount;
    transaction.note = this.editTransactionForm.value.note;
    transaction.date = this.editTransactionForm.value.date;

    this.transactionService
      .updateTransaction(transaction.id, transaction)
      .subscribe({
        next: (res) => this.toastrService.success('Successfully updated!'),
        error: (err) => this.toastrService.error('Error!'),
        complete: () => this.loadAllDataForTrasactionTable(),
      });
  }

  Delete(id: number) {
    this.transactionService.deleteTransaction(id).subscribe({
      next: (res) => this.toastrService.success('Successfully deleted!'),
      error: (err) => this.toastrService.error('Error!'),
      complete: () => this.loadAllDataForTrasactionTable(),
    });
  }

  onSelect() {
    const selectedTeamId = this.addTransactionForm.value.teamId;

    const filteredUserTeams = this.userTeams.filter(
      (ut) => ut.teamId == selectedTeamId
    );

    this.usersOfmySelectedTeam = filteredUserTeams.map(
      (ut) => this.users.filter((u) => u.id == ut.userId)[0]
    );
  }

  onSubmit() {
    const userTeam = this.userTeams.filter(
      (ut) =>
        this.addTransactionForm.value.teamId == ut.teamId &&
        this.addTransactionForm.value.userId == ut.userId
    )[0];

    const formValue = this.addTransactionForm.value;

    let transaction: Transaction = <Transaction>{
      userTeamId: userTeam.id,
      amount: formValue.amount,
      date: <Date>formValue.date,
      note: formValue.note,
    };

    this.transactionService.addTransaction(transaction).subscribe({
      next: () => this.toastrService.success('Successfully added transaction!'),
      error: (err) => this.toastrService.error('Error!'),
      complete: () => this.loadAllDataForTrasactionTable(),
    });
  }

  openAddTransactionModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openEditTransactionModal(template: TemplateRef<any>, transactionId: number) {
    let transaction = this.transactions.find((t) => t.id == transactionId);
    let userTeam = this.userTeams.find((ut) => ut.id == transaction.userTeamId);
    let user = this.users.find((u) => u.id == userTeam.userId);
    let team = this.teams.find((t) => t.id == userTeam.teamId);

    this.editTransactionForm = new FormBuilder().group({
      name: [{ value: user.name, disabled: true }],
      teamName: [{ value: team.name, disabled: true }],
      amount: [{ value: transaction.amount, disabled: false }],
      date: [{ value: transaction.date, disabled: false }],
      note: [{ value: transaction.note, disabled: false }],
      id: transaction.id,
    });

    this.modalRef = this.modalService.show(template);
  }

  openDeleteTransactionModal(
    template: TemplateRef<any>,
    transactionId: number
  ) {
    this.modalRef = this.modalService.show(template);
    this.modalRef.content = transactionId;
  }
}
