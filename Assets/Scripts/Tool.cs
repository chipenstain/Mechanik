using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanik
{
    public struct Tool
    {
        public GameObject render;
		public Vector3[] positions;

		public Tool(GameObject tool, Vector3[] positions)
		{
			render = tool;
			this.positions = positions;
		}
    }
}
