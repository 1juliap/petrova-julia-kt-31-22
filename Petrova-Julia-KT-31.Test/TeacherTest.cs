using Petrova_Julia_KT_31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrova_Julia_KT_31.Test
{
    public class TeacherTest
    {
        [Fact]
        public void HasFullName_AllFieldsFilled_True()
        {
            //arrange
            var teacher = new Teacher
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович"
            };

            //act
            var result = teacher.HasFullName();

            //assert
            Assert.True(result);
        }

        [Fact]
        public void HasFullName_MissingMiddleName_False()
        {
            //arrange
            var teacher = new Teacher
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = ""
            };

            //act
            var result = teacher.HasFullName();

            //assert
            Assert.False(result);
        }
    }
}
