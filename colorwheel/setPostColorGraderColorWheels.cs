// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Color Wheel")]
	[Tooltip("Set Color Grading Color Wheels Post Processing Effects.")]
	public class setPostColorGraderColorWheels : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		[ObjectType(typeof(ColorGradingModel.ColorWheelMode))]
		public FsmEnum mode;

		[UIHint(UIHint.Variable)]
		public FsmColor logSlope;
		[UIHint(UIHint.Variable)]
		public FsmColor logPower;
		[UIHint(UIHint.Variable)]
		public FsmColor logOffset;
		[UIHint(UIHint.Variable)]
		public FsmColor linearLift;
		[UIHint(UIHint.Variable)]
		public FsmColor linearGamma;
		[UIHint(UIHint.Variable)]
		public FsmColor linearGain;

		public FsmBool everyFrame;


		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{
			logSlope = null;
			logPower = null;
			logOffset = null;
			linearGain = null;
			linearGamma = null;
			linearLift = null;
			everyFrame = false;

		}
        

		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget (gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			if (!everyFrame.Value)
			{
				doPostProcess();
				Finish();
			}

		}


		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				doPostProcess();
			}
		}


		void doPostProcess()
		{

			var go = Fsm.GetOwnerDefaultTarget (gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			behavior.colorGrading.colorWheels.mode = (ColorGradingModel.ColorWheelMode)mode.Value;
			behavior.colorGrading.colorWheels.linear.gain = linearGain.Value;
			behavior.colorGrading.colorWheels.linear.gamma = linearGamma.Value;
			behavior.colorGrading.colorWheels.linear.lift = linearLift.Value;
			behavior.colorGrading.colorWheels.log.offset = logOffset.Value;
			behavior.colorGrading.colorWheels.log.power = logPower.Value;
			behavior.colorGrading.colorWheels.log.slope = logSlope.Value;

		}

	}
}