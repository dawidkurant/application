import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from "../product";
import { Category } from "../category";
import { Unit } from "../unit";
import { Group } from "../group";
import { ProductsService } from '../products.service';
import { CategoriesService } from '../categories.service';
import { UnitsService } from '../units.service';
import { GroupsService } from '../groups.service';
 
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
 
  productId: number;
  product: Product;
  categories: Category[] = [];
  units: Unit[] = [];
  groups: Group[] = [];
  editForm;
 
  constructor(
    public productsService: ProductsService,
    public categoriesService: CategoriesService,
    public unitsService: UnitsService,
    public groupsService: GroupsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      productName: ['', Validators.required],
      categoryName: [''],
      groupName: [''],
      unitName: [''],
      weight: [''],
      productImagePath: [''],
    });
  }
 
  ngOnInit(): void {
    this.productId = this.route.snapshot.params['productId'];
 
    this.categoriesService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });

    this.unitsService.getUnits().subscribe((data: Unit[]) => {
      this.units = data;
    });

    this.groupsService.getGroups().subscribe((data: Group[]) => {
      this.groups = data;
    });
 
    this.productsService.getProduct(this.productId).subscribe((data: Product) => {
      this.product = data;
      this.editForm.patchValue(data);
    });
  }
 
  onSubmit(formData) {
    this.productsService.updateProduct(this.productId, formData.value).subscribe(res => {
      this.router.navigateByUrl('/products/list');
    });
  }
}
