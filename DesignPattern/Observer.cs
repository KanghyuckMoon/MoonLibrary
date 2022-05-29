using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.DesignPattern
{
	public abstract class ObserverObject : MonoBehaviour, IObserver
	{
		public abstract void GetNotify();
	}
}
