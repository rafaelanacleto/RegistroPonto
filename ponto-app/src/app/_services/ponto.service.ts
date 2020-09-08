import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ponto } from '../_models/Ponto'

@Injectable({
    providedIn: 'root'
})
export class PontoService {

    pontos: Object;
    baseURL = 'http://localhost:5000/pontoregistro';
    tokenHeader: HttpHeaders;

    constructor(private http: HttpClient) { }

    getAllPonto(): Observable<Ponto[]> {
        return this.http.get<Ponto[]>(this.baseURL);
    }

    postPonto(ponto: Ponto) {
        return this.http.post(this.baseURL, ponto);
    }

    deletePonto(IdPonto: number) {
        return this.http.delete(`${this.baseURL}/${IdPonto}`, { headers: this.tokenHeader });
    }

}
