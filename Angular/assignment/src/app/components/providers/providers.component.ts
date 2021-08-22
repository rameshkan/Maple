import { Component, Input } from '@angular/core';

@Component({
     selector: 'app-providers',
     templateUrl: './providers.component.html',
     styleUrls: ['./providers.component.css']
})

export class ProvidersComponent {
     @Input() providers: any[]
     constructor() {
     }

}

