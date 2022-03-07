import { Observable, lastValueFrom } from 'rxjs';
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
  constructor(
    private userTeamService: UserTeamService,
    private teamService: TeamService
  ) {}

  getProfile(): User {
    return JSON.parse(localStorage.getItem('user'));
  }

  public async getMyActiveTeamsAsync() {
    let teams: Team[] = [];
    let userTeams: UserTeam[] = [];
    let myTeams: Team[] = [];
    const myProfile = this.getProfile();

    const teams$ = this.teamService.getAllTeams();
    const userTeams$ = this.userTeamService.getAllUserTeams();

    teams = await lastValueFrom(teams$);
    userTeams = await lastValueFrom(userTeams$);

    userTeams
      .filter((ut) => ut.isActive && ut.userId == myProfile.id)
      .forEach((ut) =>
        myTeams.push(teams.find((t) => t.id == ut.teamId))
      );

    return myTeams;
  }
}
