import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { ApiService } from 'src/app/shared/services/apiservices';

@Component({
     selector: 'app-services',
     templateUrl: './services.component.html',
     styleUrls: ['./services.component.css']
})


export class ServicesComponent implements OnInit{
     @ViewChild('serviceList') divContainer: any;
 

     services: any = [];
     providers: any = [];
     constructor(private renderer: Renderer2, private webapi: ApiService,) {
     }
     ngOnInit(): void {
          this.webapi.get("services").then(
               (result) => {
                    if (result && result.data) {
                          result.data.forEach((element) => {
                              var service = {
                                   name: element.attributes.name,
                                   id: element.id
                              };
                              this.services.push(service);
                         });
                    }
               });
     }

     loadproviders(serviceName, eref)
     {
          this.divContainer.nativeElement.querySelectorAll('.card_highlight').forEach(
               serviceDiv => {
                    serviceDiv.classList.remove('card_highlight');
               }
          )
          this.renderer.addClass(eref, "card_highlight");
          this.providers = [];
          //do not know the service signature to pass serviceid, hence fetching all records and filtering on the result
          this.webapi.get("providers?include=locations,schedules.location").then(
               (result) => {
                    if (result && result.data) {
                         result.data.forEach((element) => {
                         
                              if (element.attributes.subspecialties && element.attributes.subspecialties.length > 0)
                              {
                                   element.attributes.subspecialties.forEach((spec) => {
                                        if (spec.toUpperCase() == serviceName.toUpperCase()) {
                                             var provider = {
                                                  name: element.attributes.name,
                                                  imageUrl: element.attributes["card-image"],
                                                  specialities: element.attributes["subspecialties"].join(", ")
                                             };
                                             this.providers.push(provider);
                                        }
                                   });
                              }


                              
                         });
                    }
               });
     }

}

