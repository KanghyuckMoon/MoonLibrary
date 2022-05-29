using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonLibrary.Math
{
	public static class Parabola
    {
        /// <summary>
        /// 최고 높이 계산
        /// </summary>
        /// <param name="force">초기 벡터</param>
        /// <param name="rad">사인 함수의 라디안값</param>
        /// <param name="multiple">배수</param>
        /// <returns></returns>
        public static float ReturnMaxHeight(float force, float rad, float multiple = 1)
        {
            float height = ((force * force) * (Mathf.Sin(rad) * Mathf.Sin(rad)) / Mathf.Abs((Physics2D.gravity.y * 2))) * multiple;
            return height;
        }

        /// <summary>
        /// 수평 도달 거리 계산
        /// </summary>
        /// <param name="force">초기 벡터</param>
        /// <param name="rad">사인 함수의 라디안 값</param>
        /// <returns></returns>
        public static float ReturnWidth(float force, float rad)
        {
            return (force * force) * (Mathf.Sin(rad * 2)) / Mathf.Abs(Physics2D.gravity.y);
        }

        /// <summary>
        /// 최고점 도달 시간
        /// </summary>
        /// <param name="force">초기 벡터</param>
        /// <param name="rad">사인 함수의 라디안값</param>
        /// <param name="multiple">시간 배수. 1이면 최고점 도달 시간, 2이면 수평 도달 시간</param>
        /// <returns></returns>
        public static float ReturnTimeToMaxHeight(float force, float rad, float multiple = 1)
        {
            return Mathf.Abs(force * Mathf.Sin(rad) / Mathf.Abs(Physics2D.gravity.y) * multiple);
        }

        /// <summary>
        /// t초 후의 위치
        /// </summary>
        /// <param name="force">초기 벡터</param>
        /// <param name="rad">사인 함수의 라디안값</param>
        /// <param name="time">시간</param>
        /// <returns></returns>
        public static float ReturnTimeToPos(float force, float rad, float time)
        {
            return (force * time * Mathf.Sin(rad)) - (Mathf.Abs(Physics2D.gravity.y / 2) * (time * time));
        }
    }
}
