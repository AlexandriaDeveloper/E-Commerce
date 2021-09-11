export class ShopParams{
    brandId:number |null=0;
    typeId:number |null=0;
    sort ='name';
    pageNumber =1;
    pageSize =6;
    totalCount: number=0;
    search: string;
}