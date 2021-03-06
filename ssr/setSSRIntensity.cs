// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing SSR")]
	[Tooltip("Set Screen Space Relection Intensity in Post Processing Effects.")]
	public class  setSSRIntensity : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat reflectionMultiplier;
		public FsmInt fadeDistance;
		public FsmFloat fresnelFade;
		public FsmFloat fresnelFadePowder;
		
		public FsmBool everyFrame;
			       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{

			
			reflectionMultiplier = new FsmFloat{ UseVariable = true};
			fadeDistance = new FsmInt{ UseVariable = true};
			fresnelFade = new FsmFloat{ UseVariable = true};
			fresnelFadePowder = new FsmFloat{ UseVariable = true};
			everyFrame = false;
		}

		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			doPostProcess();
			
			if (!everyFrame.Value)
			{
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

			if(!reflectionMultiplier.IsNone)  
			{			
				behavior.screenSpaceReflection.intensity.reflectionMultiplier = reflectionMultiplier.Value;
			}
			
			if(!fadeDistance.IsNone)  
			{			
				behavior.screenSpaceReflection.intensity.fadeDistance = fadeDistance.Value;
			}
			
			if(!fresnelFade.IsNone)  
			{			
				behavior.screenSpaceReflection.intensity.fresnelFade = fresnelFade.Value;
			}
			
			if(!fresnelFadePowder.IsNone)  
			{			
				behavior.screenSpaceReflection.intensity.fresnelFadePower = fresnelFadePowder.Value;
			}
			
		}

	}
}