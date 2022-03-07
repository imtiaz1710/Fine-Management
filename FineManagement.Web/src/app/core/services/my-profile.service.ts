import { Observable } from 'rxjs';
import { UserTeam } from './../models/user-team';
import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { User } from '../models/user';
import { TeamService } from './team.service';
import { UserTeamService } from './user-team.service';

@Injectable({
  providedIn: 'root',
})
export class MyProfileService {
  teams: Team[] = [];
  userTeams: UserTeam[] = [];
  myTeams: Team[] = [];

  constructor(
    private userTeamService: UserTeamService,
    private teamService: TeamService
  ) {}

  getProfile(): User {
    return JSON.parse(localStorage.getItem('user'));
  }

  public async getMyActiveTeamsAsync() {
    const myProfile = this.getProfile();

    await this.teamService.getAllTeams().subscribe({
      next: (ts) => {
        this.teams = ts;
        console.log(this.teams);
      },
      error: (err) => console.log(err),
    });

    await this.userTeamService.getAllUserTeams().subscribe({
      next: (uts) => {
        this.userTeams = uts;

        this.userTeams
          .filter((ut) => ut.isActive && ut.userId == myProfile.id)
          .forEach((ut) => this.myTeams.push(this.teams.find((t) => t.id == ut.teamId)));
      },
      error: (err) => console.log(err),
    });

     console.log(this.teams)
     console.log(this.userTeams)
     console.log('this is:', this.myTeams)
    return this.myTeams;
  }
}
