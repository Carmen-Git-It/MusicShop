using AutoMapper;
using CW2237A2.Data;
using CW2237A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-bde95ce3-007f-4c36-9e78-14f2c0b2fe82
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace CW2237A2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                
                // Track Maps
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();

                // Invoice Maps
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();

                // InvoiceLine Maps
                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        /*
         * Track Methods
        */
        public IEnumerable<TrackWithDetailViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Include("Genre").Include("Album")
                .OrderBy(track => track.Name)
                );
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetBluesJazz()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Include("Genre").Include("Album")
                .Where(track => track.GenreId == 2 || track.GenreId == 6)
                .OrderBy(track => track.Genre.Name).ThenBy(track => track.Name)
                );
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetCantrellStaley()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Include("Genre").Include("Album")
                .Where(track => track.Composer.Contains("Jerry Cantrell") && track.Composer.Contains("Layne Staley"))
                .OrderBy(track => track.Composer).ThenBy(track => track.Name)
                );
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Longest()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Include("Genre").Include("Album")
                .OrderByDescending(track => track.Milliseconds)
                .Take(50)
                .OrderBy(track => track.Name)
                );
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Smallest()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(
                ds.Tracks.Include("Genre").Include("Album")
                .OrderBy(track => track.Bytes)
                .Take(50)
                .OrderBy(track => track.Name)
                );
        }


        /*
         * Invoice Methods
        */

        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(
                ds.Invoices.Include("Customer")
                .OrderByDescending(invoice => invoice.InvoiceDate)
                );
        }

        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int id)
        {
            var invoice = ds.Invoices.Include("Customer.Employee")
                .Include("InvoiceLines.Track.Album.Artist")
                .Include("InvoiceLines.Track.Genre")
                .Include("InvoiceLines.Track.MediaType")
                .FirstOrDefault(i => i.InvoiceId == id);

            return invoice == null ? null : mapper.Map<Invoice, InvoiceWithDetailViewModel>(invoice);
        }
    }
}