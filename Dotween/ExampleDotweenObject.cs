using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.Dotween
{
	public class ExampleDotweenObject : MonoBehaviour
	{
		[SerializeField]
		private ExampleUIDGManager exampleUIDGManager = null;

		public void Start()
		{
			exampleUIDGManager.GetSequence("UIClose", GetComponent<RectTransform>());
		}
	}
}
