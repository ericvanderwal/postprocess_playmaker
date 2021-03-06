// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Tonemapping")]
	[Tooltip("Set Color Grading Tonemapping Post Processing Effects.")]
	public class setPostColorGradeTonemapping : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(ColorGradingModel.Tonemapper))]
		public FsmEnum tonemapper;

		[UIHint(UIHint.Variable)]
		public FsmFloat blackIn;

		[UIHint(UIHint.Variable)]
		public FsmFloat whiteIn;

		[UIHint(UIHint.Variable)]
		public FsmFloat blackOut;

		[UIHint(UIHint.Variable)]
		public FsmFloat whiteOut;

		[UIHint(UIHint.Variable)]
		public FsmFloat whiteLevel;

		[UIHint(UIHint.Variable)]
		public FsmFloat whiteClip;

		public FsmBool everyFrame;


		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{
			blackIn = null;
			blackOut = null;
			whiteOut = null;
			whiteIn = null;
			whiteLevel = null;
			whiteClip = null;
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

			behavior.colorGrading.tonemapping.tonemapper = (ColorGradingModel.Tonemapper)tonemapper.Value;
			behavior.colorGrading.tonemapping.neutralBlackIn = blackIn.Value;
			behavior.colorGrading.tonemapping.neutralBlackOut = blackOut.Value;
			behavior.colorGrading.tonemapping.neutralWhiteClip = whiteClip.Value;
			behavior.colorGrading.tonemapping.neutralWhiteIn = whiteIn.Value;
			behavior.colorGrading.tonemapping.neutralWhiteOut = whiteOut.Value;
			behavior.colorGrading.tonemapping.neutralWhiteLevel = whiteLevel.Value;

		}


	}
}