import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';

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
  createForm: FormGroup;

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
      groupId: this.formBuilder.array([]),
      unitName: [''],
      weight: ['500', Validators.required],
      iron: ['0'],
      vitaminB12: ['0'],
      folate: ['0'],
      vitaminD: ['0'],
      calcium: ['0'],
      magnesium: ['0'],
      fiber: ['0'],
      protein: ['0'],
      fat: ['0'],
      assimilableCarbohydrates: ['0'],
      carbohydrateReplacement: ['0'],
      productImagePath: [''],
    });
  }

  onChange(groupId: number, isChecked: boolean) {
    const groups = (this.createForm.controls.groupId as FormArray);

    if (isChecked) {
      groups.push(new FormControl(groupId));
    } else {
      const index = groups.controls.findIndex(x => x.value === groupId);
      groups.removeAt(index);
    }
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
      console.log(res);
      this.router.navigateByUrl('/products/list');
    });
  }

}
