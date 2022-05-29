using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonLibrary.DesignPattern
{
	public interface IObserver
	{
		/// <summary>
		/// 관찰자가 관찰 대상에게서 메시지를 받았을 때 사용하는 함수
		/// </summary>
		void GetNotify(); 
	}
}
