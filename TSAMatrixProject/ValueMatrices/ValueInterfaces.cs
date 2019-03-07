using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSAMatrixProject;
using TSAMatrixProject.Exceptions;

namespace TSAMatrixProject.ValueMatrices.Interfaces {

    //TODO: Flesh these out.
    
    public interface IValueSquare {
        //determinant, minor, trace
    }

    public interface IValueDiagonal : IValueSquare {
        //trace/idk lol
    }

    public interface IValueIdentity : IValueDiagonal {
        //idk lol
    }

   
}
