﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
	public partial interface INewsDAL : IBaseDAL<News>
    {
    }

	public partial interface INewsColumnDAL : IBaseDAL<NewsColumn>
    {
    }


}