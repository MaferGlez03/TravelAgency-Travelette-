import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class IdService {
    isRegisteredSource = new BehaviorSubject<boolean>(false);
    isRegistered = this.isRegisteredSource.asObservable();

    private idSource = new BehaviorSubject<string | null>(null);
    currentId = this.idSource.asObservable();

    idUser = ""

    constructor() { }

    changeId(username: string, id: string) {
        this.isRegisteredSource.next(true);
        this.idSource.next(username);
        this.idUser = id
    }
}
