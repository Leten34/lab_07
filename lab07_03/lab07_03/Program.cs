using System;
namespace lab07_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item();
            item1.Print();
            Magazine mag1 = new Magazine("О природе", 5, "Земля и мы", 2014, 1235, true);
            Book b3 = new Book("Лермонтов М.Ю.", "Мцыри");
            Book b2 = new Book("Толстой Л.Н.", "Война и мир", "Наука и жизнь", 1234, 2013, 101, true);
            Book b1 = new Book();
            b1.SetBook("Пушкин А.С.", "Капитанская дочка", "Вильямс", 123, 2018);
            mag1.TakeItem();
            mag1.Print();
            b3.Print();
            b2.TakeItem();
            b2.Print();
            Book.SetPrice(12);
            b1.Print();
            Book.SetPrice(5);
            b1.Print();
            Book.SetPrice(10);
            b1.Print();
            Console.WriteLine("Итоговая стоимость аренды: {0} р.", b1.PriceBook(3));
            Console.WriteLine("\nТестирование полиморфизма:");
            Item it;
            it = b2;
            it.TakeItem();
            it.Print();
            it = mag1;
            it.TakeItem();
            it.Print();
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
        private void Take()
        {
            taken = false;
        }
        public virtual void Return()
        {
            taken = true;
        }
        public virtual void Print()
        {
            Console.WriteLine("Состояние единицы хранения:\n Инвентарный номер: {0}\n Наличие: {1}", invNumber, taken);
        }
        public Item(long invNumber, bool taken)
        {
            this.invNumber = invNumber;
            this.taken = taken;
        }
        public Item()
        {
            this.taken = true;
        }
        public void TakeItem()
        {
            if (this.IsAvaible())
            {
                this.Take();
            }
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
        public bool returnSrok { get; private set; }
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
        public override void Print()
        {
            Console.WriteLine(this);
            base.Print();
        }
        public double PriceBook(int s)
        {
            double cust = s * Price;
            return cust;
        }
        public Book(string author, string title, string publisher, int pages, int year, long invNumber, bool taken) : base(invNumber, taken)
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
        public void ReturnSrok()
        {
            returnSrok = true;
        }
        public override void Return()
        {
            if (returnSrok == true)
            {
                taken = true;
            }
            else
            {
                taken = false;
            }
        }
    }
    class Magazine : Item
    {
        public string Volume { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Magazine(string volume, int number, string title, int year, long invNumber, bool taken) : base(invNumber, taken)
        {
            Volume = volume;
            Number = number;
            Title = title;
            Year = year;
        }
        public Magazine() { }
        public override string ToString()
        {
            string bs = String.Format("\nЖурнал:\n Том: {0}\n Номер: {1}\n Название: {2}\n Год выпуска: {3}", Volume, Number, Title, Year);
            return bs;
        }
        public override void Print()
        {
            Console.WriteLine(this);
            base.Print();
        }
        public override void Return()
        {
            taken = true;
        }
    }
}


