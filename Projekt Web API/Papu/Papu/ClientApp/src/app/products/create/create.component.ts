import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { Category } from "../category";
import { Unit } from "../unit";
import { Group } from "../group";
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { UnitsService } from '../units.service';
import { GroupsService } from '../groups.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})

export class CreateComponent implements OnInit {

  categories: Category[] = [];
  units: Unit[] = [];
  groups: Group[] = [];
  createForm;

  constructor(
    public productsService: ProductsService,
    public categoriesService: CategoriesService,
    public unitsService: UnitsService,
    public groupsService: GroupsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder) {

    this.createForm = this.formBuilder.group({
      productName: ['Przykładowa', Validators.required],
      categoryName: [''],
      groupName: [''],
      unitName: [''],
      weight: ['500'],
      productImagePath: [''],
    });
  }

  ngOnInit(): void {
    this.categoriesService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });

    this.unitsService.getUnits().subscribe((data: Unit[]) => {
      this.units = data;
    });

    this.groupsService.getGroups().subscribe((data: Group[]) => {
      this.groups = data;
    });
  }

  onSubmit(formData) {
    this.productsService.createProduct(formData.value).subscribe(res => {
      this.router.navigateByUrl('/products/list');
    });
  }

}
