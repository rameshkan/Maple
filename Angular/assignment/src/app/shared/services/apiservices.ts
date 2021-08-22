import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";


@Injectable()
export class ApiService {
     private serviceURL = environment.ServiceUrl;
     constructor(
          public httpClient: HttpClient,
     ) { }

     async post(url: string, data: any): Promise<any> {
          var res = await this.httpClient
               .post(this.serviceURL + url, data)
               .toPromise();

          return res;
     }

     async get(url : any): Promise<any> {
          var res = await this.httpClient.get(this.serviceURL + url).toPromise();
          return res;
     }
    
}
