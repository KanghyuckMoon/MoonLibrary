using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace MoonLibrary.Dotween
{
	public class ExampleUIDGManager : DotweenManager<RectTransform>
	{
		public void Awake()
		{
			RegisterSequence("UIClose", DGUIClose);
		}

		public Sequence DGUIClose(RectTransform rectTransform)
		{
			return DOTween.Sequence()
				.OnStart(() => rectTransform.localScale = Vector3.one)
				.Append(rectTransform.DOScale(1.2f, 0.2f))
				.Append(rectTransform.DOScale(0f, 0.5f));
		}
	}
}
