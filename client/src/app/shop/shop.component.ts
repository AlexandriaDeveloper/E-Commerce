import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productTypes';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search',{static :true}) searchTerm :ElementRef; 
  products :IProduct[]=[] ;

  brands:IBrand[] =[];
  types :IType[]=[];

  shopParams = new ShopParams();
  sortOptions =[
    {name : 'Alphabetical', value :'name'},
    {name : 'Price Low to High', value :'priceAsc'},
    {name : 'price High to Low', value :'priceDesc'}

];

  constructor(private shopService : ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(){

    this.shopService.getProducts(this.shopParams).subscribe(res => {
      if(res)
      {
        this.products=res.data
        this.shopParams.pageNumber= res.pageIndex;
        this.shopParams.pageSize=res.pageSize;
        this.shopParams.totalCount=res.count
      }
    }, err => 
    console.log(err))
  }


  getBrands(){
    this.shopService.getBrands()
    .subscribe( res =>{
      this.brands=[{id:0 , name:'All'},...res];
    }, err =>{
      console.log(err);

    })

  }

  
  getTypes(){
    this.shopService.getTypes()
    .subscribe( res =>{
      this.types=[{id:0, name: 'All'},...res]
     
    }, err =>{
      console.log(err);
      
    })

  }

  onBrandSelected(brandId :number){
    this.shopParams.brandId= brandId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  onTypeSelected(typeId :number){
    this.shopParams.typeId= typeId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  onSortSelected (e:Event){
    this.shopParams.sort=(e.target as HTMLSelectElement).value;
    this.getProducts();

  }
  onSortSelected2 (sort:string){
    this.shopParams.sort=sort;
    this.getProducts();

  }
  onPageChanged(ev :any){
 
    if(this.shopParams.pageNumber !== ev.page)
    {

      this.shopParams.pageNumber =ev.page;
      this.getProducts();
    }

    
}
onSearch(){
  this.shopParams.search= this.searchTerm.nativeElement.value;
  this.shopParams.pageNumber=1;
  this.getProducts();
}

onReset(){
  this.searchTerm.nativeElement.value = '';
  this.shopParams= new ShopParams();
  this.getProducts();
}

}
