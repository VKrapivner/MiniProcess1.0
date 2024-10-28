using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public static class AnimatorExtentions
	{

		public static bool HasParameter(this Animator animator, string paramName)//cat doesn't need to jump yet
		{
			foreach (AnimatorControllerParameter param in animator.parameters)
			{
				if (param.name == paramName)
					return true;
			}
			return false;
		}
	}
}
