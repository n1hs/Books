using System;
using Caliburn.Micro;

namespace BookStoreManagement.Models
{
    public class DataProvider
    {
        public BindableCollection<Book> Books { get; set; }
        public DataProvider()
        {
            Books = new BindableCollection<Book>()
            {
                new Book()
                {
                    Id = "01",
                    Title = "Sự im lặng của bày cừu.",
                    Author = "Thomas Harris",
                    Publisher = "None",
                    Left=99,
                    Location="Kệ 1",
                    Image=@"pack://application:,,,/BookStoreManagement;component/Resources/Img/1.png"
                },
                new Book()
                {
                    Id = "02",
                    Title = "2 vạn dặm dưới đáy biển (Twenty Thousand Leagues Under The Sea).",
                    Author = "Jules Verne",
                    Publisher = "None",
                    Left=99,
                    Location="Kệ 2",
                    Image=@"pack://application:,,,/BookStoreManagement;component/Resources/Img/2.png"
                },
                new Book()
                {
                    Id = "03",
                    Title = "Start With Why.",
                    Author = "Simon Sinek ",
                    Publisher = "None",
                    Left=99,
                    Location="Kệ 1",
                    Image=@"pack://application:,,,/BookStoreManagement;component/Resources/Img/3.png"
                },
                new Book()
                {
                    Id = "04",
                    Title = "Mặc Kệ Thiên Hạ.",
                    Author = "Mari Tamagawa",
                    Publisher = "None",
                    Left=99,
                    Location="Kệ 1",
                    Image=@"pack://application:,,,/BookStoreManagement;component/Resources/Img/4.png"
                },
                new Book()
                {
                    Id = "05",
                    Title = "Đời Đơn Giản Khi Ta Đơn Giản.",
                    Author = "Xuân Nguyễn",
                    Publisher = "None",
                    Left=99,
                    Location="Kệ 1",
                    Image=@"pack://application:,,,/BookStoreManagement;component/Resources/Img/5.png"
                }
            };
        }
    }
}
