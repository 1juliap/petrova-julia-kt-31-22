using Petrova_Julia_KT_31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrova_Julia_KT_31.Test
{
    public class DisciplineTest
    {
        [Fact]
        public void IsValidDisciplineName_True()
        {
            //arrange
            var testDiscipline = new Discipline
            {
                Name = "Физика"
            };

            //act
            var result = testDiscipline.IsValidDisciplineName();

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidDisciplineName_False()
        {
            //arrange
            var testDiscipline = new Discipline
            {
                Name = "123"
            };

            //act
            var result = testDiscipline.IsValidDisciplineName();

            //assert
            Assert.False(result);
        }
    }
}
