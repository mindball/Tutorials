using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Concurrency
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public ConcurrentQueue<(Customer TheCustomer, Tour TheTour)> BookingRequests { get; }
            = new ConcurrentQueue<(Customer, Tour)>(); //some data

        public async void BookTour(Customer customer)
        {
            if (customer == null)
            {
                return;
            }

            List<Tour> requestedTours = GetRequestedTours();
            if (requestedTours.Count == 0)
            {
                Console.WriteLine("You must select a tour to book!", "No tour selected");
                return;
            }

            List<Task> tasks = new List<Task>();
            foreach (Tour tour in requestedTours)
            {
                Task task = Task.Run(
                    () => this.BookingRequests.Enqueue((customer, tour)));
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("tours requested", "Tours requested");
        }

        public void ApproveRequest()
        {
            //if (AllData.BookingRequests.Count == 0) //sync way
            //	return;

            //var request = AllData.BookingRequests.Dequeue(); //sync way
            bool success = BookingRequests.TryDequeue(out var request);
            if (success)
            {
                request.TheCustomer.BookedTours.Add(request.TheTour);
            }
        }

        private List<Tour> GetRequestedTours()
        {
            return new List<Tour>();
        }
    }
}
