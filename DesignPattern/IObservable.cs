using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonLibrary.DesignPattern
{
	public interface IObservable
	{
		/// <summary>
		/// 해당 관찰 대상을 관찰하는 관찰자 추가
		/// </summary>
		void AddObserver(IObserver observer);

		/// <summary>
		/// 자신을 관찰하는 관찰자들에게 메시지를 전달하는 함수
		/// </summary>
		void PostNotify();
	}
}
