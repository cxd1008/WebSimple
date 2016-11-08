using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace IDAL
{
	public partial interface IDbSession
    {
	
		INewsDAL NewsDAL{get;set;}
	
		INewsColumnDAL NewsColumnDAL{get;set;}
	}	
}