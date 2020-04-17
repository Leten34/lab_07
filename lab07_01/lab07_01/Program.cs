using System;
namespace lab07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item();
            item1.Print();
            Book b3 = new Book("Лермонтов М.Ю.", "Мцыри");
            Book b2 = new Book("Толстой Л.Н.", "Война и мир", "Наука и жизнь", 1234, 2013);
            Book b1 = new Book();
            b1.SetBook("Пушкин А.С.", "Капитанская дочка", "Вильямс", 123, 2018);
            b3.Print();
            b2.Print();
            Book.SetPrice(12);
            b1.Print();
            Book.SetPrice(5);
            b1.Print();
            Book.SetPrice(10);
            b1.Print();
            Console.WriteLine("Итоговая стоимость аренды: {0} р.", b1.PriceBook(3));
        }
    }
    class Item
    {
        protected long invNumber;
        protected bool taken;
        public bool IsAvaible()
        {
            if (taken)
                return true;
            else
                return false;
        }
        public long GetInvNumber()
        {
            return invNumber;
        }
        public void Take()
        {
            taken = false;
        }
        public void Return()
        {
            taken = true;
        }
        public void Print()
        {
            Console.WriteLine("Состояние единицы хранения:\n Инвентарный номер: {0}\n Наличие: {1}", invNumber, taken);
        }
    }
    class Book : Item
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public static double Price { get; set; }
        public void SetBook(string author, string title, string publisher, int pages, int year)
        {
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.Pages = pages;
            this.Year = year;
        }
        public static void SetPrice(double price)
        {
            Book.Price = price;
        }
        public override string ToString()
        {
            string bs = String.Format("\nКнига:\n Автор: {0}\n Название: {1}\n Год издания: {2}\n {3} стр.\n Стоимость аренды: {4}", Author, Title, Year, Pages, Price);
            return bs;
        }
        new public void Print()
        {
            Console.WriteLine(this);
        }
        public double PriceBook(int s)
        {
            double cust = s * Price;
            return cust;
        }

        public Book(string author, string title, string publisher, int pages, int year)
        {
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.Pages = pages;
            this.Year = year;
        }
        public Book() { }
        static Book()
        {
            Price = 9;
        }
        public Book(string author, string title)
        {
            this.Author = author;
            this.Title = title;
        }
        public void TakeItem()
        {
            if (this.IsAvaible())
            {
                this.Take();
            }
        }
    }

}