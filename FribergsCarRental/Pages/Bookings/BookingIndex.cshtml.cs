﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Bookings
{
    public class BookingIndexModel : PageModel
    {
        private readonly IBooking bookingRepository;

        public BookingIndexModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = (await bookingRepository.GetAllBookingAsync()).ToList();
        }

    
    }
}
