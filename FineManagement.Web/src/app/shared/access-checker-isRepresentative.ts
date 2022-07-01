import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../core/models/user';
import { UserTeamService } from '../core/services/user-team.service';

@Injectable()
export class AccessCheckerIsRepresentative {

    constructor(private router: Router, private userTeamService: UserTeamService) { }

     isRepresentative() {
        const  user: User = JSON.parse(localStorage.getItem('user'));

        if (user?.isRepresentativeOfTeam) {
            return true;
        }
        else return false;
    }
}
