// Copyright (C) 2013 Zeno Gantner
//
// This file is part of MyMediaLite.
//
// MyMediaLite is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MyMediaLite is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with MyMediaLite.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections.Generic;

namespace MyMediaLite
{
	abstract public class ModelBasedMethod : IMethod
	{
		public virtual Dictionary<string, object> DefaultParameters { get { return new Dictionary<string, object>(); } }

		public virtual bool SupportsUpdate { get { return false; } }

		abstract public IModel LoadModel(string filename);
		abstract public IModel Train(IDataSet dataset, Dictionary<string, object> parameters = null);

		public virtual IModel Update(
			IModel model, IDataSet dataset,
			IList<int> modifiedUsers, IList<int> modifiedItems,
			Dictionary<string, object> parameters = null)
		{
			throw new NotSupportedException();
		}

		abstract public IRecommender CreateRecommender(IModel model);
		public virtual IRecommender CreateRecommender(IModel model, IDataSet dataset)
		{
			return CreateRecommender(model);
		}

	}
}

