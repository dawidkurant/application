import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

import { Nationality } from "./nationality";
import { NationalitiesService } from "./nationalities.service";


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  nationalities: Nationality[] = [];
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private nationalitiesService: NationalitiesService) {
    this.registerForm = this.fb.group({
      'email': ['', Validators.required],
      'password': ['', Validators.required],
      'confirmPassword': ['', Validators.required],
      'nationality': ['', Validators.required],
      'dateOfBirth': ['', Validators.required],
    })
  
  }

  ngOnInit(): void {
    this.nationalities = this.nationalitiesService.getNationalities();
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      console.log(data);
    });
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  get nationality() {
    return this.registerForm.get('nationality');
  }

  get dateOfBirth() {
    return this.registerForm.get('dateOfBirth');
  }
}
