import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./pages/home/home.component";
import { Error404Component } from "./pages/error-404/error-404.component";
import { BlogComponent } from "./pages/blog/blog.component";
import { ContactComponent } from "./pages/contact/contact.component";
import { ServiceComponent } from "./pages/service/service.component";
import { AppointmentComponent } from "./pages/appointment/appointment.component";
import { LoginComponent } from "./pages/auth/login/login.component";
import { MainComponent } from "./layouts/main/main.component";
import { AuthComponent } from "./layouts/auth/auth.component";
import { AdminComponent } from "./layouts/admin/admin.component";
import { DashboardComponent } from "./admin/dashboard/dashboard.component";
import { UserComponent } from "./user/user.component";
import { SignupComponent } from "./signup/signup.component";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { routes } from "./app.routes";
import { HttpClient } from "@angular/common/http";

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        Error404Component,
        BlogComponent,
        ContactComponent,
        ServiceComponent,
        AppointmentComponent,
        LoginComponent,
        MainComponent,
        AuthComponent,
        AdminComponent,
        DashboardComponent,
        UserComponent,
        SignupComponent,
    ],
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(routes),
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule { }