using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace RandomTest
{
    class Program
    {
        private static async Task MakeHttpCall()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri("https://www.google.com"),
                        Method = HttpMethod.Get,
                    })
                    {
                        Console.WriteLine("make #1");
                        //request.Headers.Add("User-Agent", "Other");
                        var resp = await client.SendAsync(request);
                        Console.WriteLine("make #2");
                        // using (var response = client.SendAsync(request).Result)
                        // {
                        //     if (response.IsSuccessStatusCode)
                        //     {
                        //         Console.WriteLine("OK");
                        //     }
                        // }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async void Redirect()
        {
            while (true)
            {
                Console.WriteLine("redirect");
                await MakeHttpCall();
            }
        }

        static void F4()
        {
            string stacknow = new System.Diagnostics.StackTrace(true).ToString();
            Console.WriteLine(stacknow);
        }

        static void F3()
        {
            F4();
        }

        static void F2()
        {
            F3();
        }

        static void F1()
        {
            F2();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<char, int> occurrence = new Dictionary<char, int>();
            string ip;

            // Test printing the stack trace
            //F1();

            Console.WriteLine("Enter string:");
            ip = Console.ReadLine();

            foreach (char x in ip)
            {
                if (x != ' ')
                {
                    char c = char.ToLower(x);
                    if (occurrence.ContainsKey(c))
                    {
                        occurrence[c]++;
                    }
                    else
                    {
                        occurrence[c] = 1;
                    }
                }
            }

            int high = 0;
            char hichar = ' ';
            foreach (var x in occurrence)
            {
                //find which is highest
                if (x.Value > high)
                {
                    high = x.Value;
                    hichar = x.Key;
                }
            }

            Console.WriteLine("Most occurrences: " + hichar + " -> " + high + " times");
        }
    }
}
