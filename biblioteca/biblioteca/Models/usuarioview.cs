using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca.Models
{
    
    public class Ultimos10view
    {
        public Object titulo { set; get; }
        public Object nombre { set; get; }
        public Object ap { set; get; }
    }
    public class usuarioview
    {
        public Object nombre { set; get; }
        public Object app { set; get; }
        public Object apm { set; get; }
        public Object Intereses { set; get; }
        public Object Ubicacion { set; get; }
        public Object email { set; get; }
        public Object nombreus { set; get; }
    }
       public class articuloview
        {
            public Object titulo { set; get; }
            public Object nombre { set; get; }
            public Object ap { set; get; }
            public Object desc { set; get; }
        }

    public class cursoview
    {
        public Object titulo { set; get; }
        public Object nombre { set; get; }
        public Object ap { set; get; }
        public Object desc { set; get; }

    }
    public class tutorialview
    {
        public Object titulo { set; get; }
        public Object nombre { set; get; }
        public Object ap { set; get; }
        public Object desc { set; get; }

    }
    public class libroview
    {
        public Object titulo { set; get; }
        public Object nombre { set; get; }
        public Object ap { set; get; }
        public Object desc { set; get; }
        

    }
    
}