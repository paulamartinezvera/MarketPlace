import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public listCartBook: Book[] = [];
  public totalPrice = 0;
  public Math = Math;

  constructor(
    private readonly _bookService: BookService,
    private router: Router
  ) { 
    var usuarioSesion= sessionStorage.getItem('user'); 
    if(usuarioSesion=="[]" || usuarioSesion==null){
      this.navTo("login");
    }
  }

  ngOnInit(): void {
    this.listCartBook = this._bookService.getBooksFromCart();
    this.totalPrice = this.getTotalPrice(this.listCartBook);
  }

  public getTotalPrice(listCartBook: Book[]): number {
    let totalPrice = 0;
    listCartBook.forEach((book: Book) => {
      totalPrice += book.amount * book.price;
    });
    return totalPrice;
  }

  public onInputNumberChange(action: string, book: Book): void {
    const amount = action === 'plus' ? book.amount + 1 : book.amount - 1;
    book.amount = Number(amount);
    this.listCartBook = this._bookService.updateAmountBook(book);
    this.totalPrice = this.getTotalPrice(this.listCartBook);
  }

  public onClearBooks(): void {
    if (this.listCartBook && this.listCartBook.length > 0) {
      this._clearListCartBook();
    } else {
       console.log("No books available");
    }
  }

  private _clearListCartBook() {
    this.listCartBook = [];
    this._bookService.removeBooksFromCart();
  }
  public buyBooks(){
    for(var i=0;i<this.listCartBook.length;i++){
      var userString= sessionStorage.getItem('user'); 
      alert("userString "+userString);
      var userJson=JSON.parse(userString);
      this.listCartBook[i].userId=userJson[0].Id;
      if(this.listCartBook.length-i==1){
        this._bookService.buyBooks(this.listCartBook).subscribe(()=>{
          this._bookService._toastSuccess(this.listCartBook[0]);
        });
      }
    }
   
  }
  navTo(path: string): void {
    this.router.navigate([`/${path}`]);

  }
}
