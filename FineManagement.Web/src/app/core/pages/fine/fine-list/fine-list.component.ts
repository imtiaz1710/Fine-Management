import { lastValueFrom } from 'rxjs';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { FineTypes } from 'src/app/core/enums/fine-types';
import { Fine } from 'src/app/core/models/fine';
import { Team } from 'src/app/core/models/team';
import { User } from 'src/app/core/models/user';
import { UserTeam } from 'src/app/core/models/user-team';
import { FineService } from 'src/app/core/services/fine.service';
import { MyProfileService } from 'src/app/core/services/my-profile.service';
import { TeamService } from 'src/app/core/services/team.service';
import { UserTeamService } from 'src/app/core/services/user-team.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-fine-list',
  templateUrl: './fine-list.component.html',
  styleUrls: ['./fine-list.component.scss'],
})
export class FineListComponent implements OnInit {
  modalRef: BsModalRef;
  users: User[] = [];
  teams: Team[] = [];
  userTeams: UserTeam[] = [];
  myTeams: Team[] = [];
  fines: Fine[] = [];
  filteredFineList: Fine[] = [];
  rows = [];
  editFineForm: FormGroup;
  fineTypes = FineTypes;
  keys = Object.keys;

  constructor(
    private teamService: TeamService,
    private userService: UserService,
    private userTeamService: UserTeamService,
    private toastrService: ToastrService,
    private myProfileService: MyProfileService,
    private fineService: FineService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.loadAllDataForFineList();
  }

  private async loadAllDataForFineList() {
    this.filteredFineList = [];
    const fines$ =  this.fineService.getAllFines();
    const users$ = this.userService.getAllUsers();
    const teams$ = this.teamService.getAllTeams();
    const userTeams$ = this.userTeamService.getAllUserTeams();

    this.fines = await lastValueFrom(fines$);
    this.users = await lastValueFrom(users$);
    this.teams = await lastValueFrom(teams$);
    this.userTeams = await lastValueFrom(userTeams$);
    this.myTeams = await this.myProfileService.getMyActiveTeamsAsync();
    
    this.loadFineList();
    this.rows = this.formateFineList();
  }

  private formateFineList() {
    return this.filteredFineList.map((fl) => {
      let userTeam = this.userTeams.filter((ut) => ut.id == fl.userTeamId)[0];
      let user = this.users.filter((u) => u.id == userTeam.userId)[0];
      let team = this.teams.filter((t) => t.id == userTeam.teamId)[0];
      return {
        name: user.name,
        teamName: team.name,
        fineType: this.fineTypes[fl.fineType],
        fineAmount: fl.fineAmount,
        date: fl.date,
        note: fl.note,
        id: fl.id,
      };
    });
  }

  private loadFineList() {
    this.myTeams.forEach(x=> {var t = x.id})

    this.myTeams.forEach((myTeam) => {
      console.log(myTeam)
      let userTeams = this.userTeams.filter((ut) => myTeam.id == ut.teamId);

      userTeams.forEach((ut) => {
        let fines = this.fines.filter((f) => f.userTeamId == ut.id);
        this.filteredFineList.push(...fines);
      });
    });
  }

  edit(id: number) {
    let fine = this.fines.find((f) => f.id == id);

    fine.fineType = this.editFineForm.value.fineType;
    fine.fineAmount = this.editFineForm.value.fineAmount;
    fine.note = this.editFineForm.value.note;
    fine.date = this.editFineForm.value.date;

    this.fineService.updateFine(fine.id, fine).subscribe({
      next: (res) => this.toastrService.success('Successfully updated!'),
      error: (err) => this.toastrService.error('Error!'),
      complete: () => this.loadAllDataForFineList(),
    });
  }

  Delete(value) {
    this.fineService.deleteFine(value).subscribe({
      next: (res) => this.toastrService.success('Successfully deleted!'),
      error: (err) => this.toastrService.error('Error!'),
      complete: () => this.loadAllDataForFineList(),
    });
  }

  openEditFineModal(template: TemplateRef<any>, fineId: number) {
    let fine = this.fines.filter((f) => f.id == fineId)[0];
    let userTeam = this.userTeams.filter((ut) => ut.id == fine.userTeamId)[0];
    let user = this.users.filter((u) => u.id == userTeam.userId)[0];
    let team = this.teams.filter((t) => t.id == userTeam.teamId)[0];

    this.editFineForm = new FormBuilder().group({
      name: [{ value: user.name, disabled: true }],
      teamName: [{ value: team.name, disabled: true }],
      fineType: [{ value: fine.fineType, disabled: false }],
      fineAmount: [{ value: fine.fineAmount, disabled: false }],
      date: [{ value: fine.date, disabled: false }],
      note: [{ value: fine.note, disabled: false }],
      id: fine.id,
    });

    this.modalRef = this.modalService.show(template);
  }

  openDeleteFineModal(template: TemplateRef<any>, fineId: number) {
    this.modalRef = this.modalService.show(template);
    this.modalRef.content = fineId;
  }
}
