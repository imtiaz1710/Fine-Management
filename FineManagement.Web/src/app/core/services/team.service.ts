import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  constructor(private http: HttpClient) {}

  addTeam(team: Team): Observable<Team> {
    return this.http.post<Team>(`https://localhost:44341/api/Team`, team);
  }

  updateTeam(id: number, team: Team): Observable<Team> {
    return this.http.put<Team>(`https://localhost:44341/api/Team/${id}`, team);
  }

  getAllTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(`https://localhost:44341/api/Team`);
  }

  deleteTeam(id: number): Observable<number> {
    return this.http.delete<number>(`https://localhost:44341/api/Team/${id}`);
  }
}
