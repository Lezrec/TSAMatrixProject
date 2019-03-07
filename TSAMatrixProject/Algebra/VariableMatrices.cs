using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSAMatrixProject.Algebra {

    public delegate double Variable(string name);

    public class VariableMatrix : Matrix<Variable>{
    }
}
