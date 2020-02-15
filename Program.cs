using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectAdventure
{
    class Program
    {
        static void Main(string[] args)
        {

            /* using (var db = new AdventureWorks2017Entities())
             {
                 var firstnameEmployees = from x in db.People
                                          group x by x.FirstName into numberCount
                                          orderby numberCount.Key
                                          select numberCount;

                 if (firstnameEmployees.Count() != 0)
                 {
                     foreach (var user in firstnameEmployees)
                     {

                         Console.WriteLine($"{user.Key},({user.Count()})");
                     }
                 }
                 else
                 {
                     Console.WriteLine("There are no users in the db.");
                 }*/

            /*Console.WriteLine("Please Enter your MiddleName.");
            var middleNameInput = Console.ReadLine();

            using (var db = new AdventureWorks2017Entities())
            {
                var firstnameEmployees = from x in db.People
                                         select x ;

                if (firstnameEmployees.Count() != 0)
                {
                    foreach (var user in firstnameEmployees)
                    {
                        *//*var userMiddleName = user.MiddleName;*//*

                        if (user.MiddleName != null)
                        {
                            if (user.MiddleName.StartsWith(middleNameInput) == true || user.MiddleName.Contains(middleNameInput) == true)
                            {
                                Console.WriteLine($"{user.FirstName},{user.MiddleName}, {user.LastName}");
                            }
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("There are no users in the db.");
                }*/



            Console.WriteLine("Please Enter your Email.");
            var emailInput = Console.ReadLine();

            using (var db = new AdventureWorks2017Entities())
            {
                var emailEmployees = from x in db.EmailAddresses
                                     join y in db.People on
                                     x.BusinessEntityID equals y.BusinessEntityID
                                     select new { firstName = y.FirstName, middleName = y.MiddleName, lastName = y.LastName, email = x.EmailAddress1 };

                if (emailEmployees.Count() != 0)
                {
                    var userList = new List<UserDetails>();

                    foreach (var user in emailEmployees)
                    {

                        if (user.email != null && user.email.Contains(emailInput) == true)
                        {
                            var userNameDetails = user.firstName + " " + user.middleName + " " + user.lastName;
                            userList.Add(new UserDetails(userNameDetails, user.email));

                            /*var json = JsonConvert.SerializeObject(new { firstname = user.firstName, middlename = user.middleName, lastname = user.lastName, email = user.email });*/
                            var json = JsonConvert.SerializeObject(userList);
                            /*var json = JsonSerializer.Serialize(userList);*/
                            Console.WriteLine(json);
                            File.AppendAllText(@"C:\Users\Krystal\Desktop\linqtext.txt", json, Encoding.UTF8);
                        }


                    }
                }
                else
                {
                    Console.WriteLine("There are no users in the db.");
                }
            }



        }
    }
}
