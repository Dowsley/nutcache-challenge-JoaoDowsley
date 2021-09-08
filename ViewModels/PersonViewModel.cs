using System;
using System.ComponentModel.DataAnnotations;
using PeopleApi.Models;
using System.Collections.Generic;

namespace PeopleApi.ViewModels
{
    public class MyViewModel
    {
        public IEnumerable<PeopleApi.Models.Person> People {get; set;}
        public PeopleApi.Models.Person Person {get; set;}
    }
}