using System;
using System.ComponentModel.DataAnnotations;

namespace MyDog.Data
{
    public class MyDogDetail
    {
           
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public string DateOfBirth { get; set; }

        public string PetWeight { get; set; }

        public string WeightUnit { get; set; }

        public string PetBreed { get; set; }


    }
}

