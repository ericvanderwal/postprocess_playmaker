// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing SSR")]
	[Tooltip("Set Screen Space Relection Post Processing Effects.")]
	public class  setSSRReflection : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		[ObjectType(typeof(ScreenSpaceReflectionModel.SSRReflectionBlendType))]
		public FsmEnum blendType;
		[ObjectType(typeof(ScreenSpaceReflectionModel.SSRResolution))]
		public FsmEnum reflectionQuality;
		public FsmFloat maxDistance;
		public FsmInt iterationCount;
		public FsmInt stepSize;
		public FsmFloat widthModifier;
		public FsmFloat reflectionBlur;
		public FsmBool reflectBackfaces;
		
		
		public FsmBool everyFrame;
			       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{

			
			blendType = new FsmEnum{ UseVariable = true};
			reflectionQuality = new FsmEnum{ UseVariable = true};
			maxDistance = new FsmFloat{ UseVariable = true};
			iterationCount = new FsmInt{ UseVariable = true};
			stepSize = new FsmInt{ UseVariable = true};
			widthModifier = new FsmFloat{ UseVariable = true};
			reflectionBlur = new FsmFloat{ UseVariable = true};
			reflectBackfaces = new FsmBool{ UseVariable = true};
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

			if(!maxDistance.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.maxDistance = maxDistance.Value;
			}
			
			if(!iterationCount.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.iterationCount = iterationCount.Value;
			}
			
			if(!stepSize.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.stepSize = stepSize.Value;
			}
			
			if(!widthModifier.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.widthModifier = widthModifier.Value;
			}
			
			if(!reflectionBlur.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.reflectionBlur = reflectionBlur.Value;
			}
			
			if(!reflectBackfaces.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.reflectBackfaces = reflectBackfaces.Value;
			}
			
			if(!blendType.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.blendType = (ScreenSpaceReflectionModel.SSRReflectionBlendType)blendType.Value;
			}
			
			if(!reflectionQuality.IsNone)  
			{			
				behavior.screenSpaceReflection.reflection.reflectionQuality = (ScreenSpaceReflectionModel.SSRResolution)reflectionQuality.Value;
			}
			
		}

	}
}