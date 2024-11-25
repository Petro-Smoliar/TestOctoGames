using CNS.Entities;
using CNS.Manager;
using CNS.Manager.Impl;
using Entities;
using Systems.ButtonSys;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Marker = CNS.Enum.Marker;

namespace CNS.Models
{
    public class Model : MonoBehaviour
    {
        [SerializeField]
        private Marker marker;
        
        public Entity Entity { get; private set; }

        [Inject]
        public void Construct(IEntityManager entityManager)
        {
            if (marker == Marker.AnswerBtn)
            {
                SetEntity(new AnswerBtn());
                entityManager.AddAnswerButton(GetComponent<Button>());
            }
            else SetEntity(new Entity());
            
            entityManager.AddEntity(Entity);
        }

        private void Start()
        {
            if (GetComponent<Button>() != null) InitButton();
        }

        private void SetEntity(Entity entity)
        {
            Entity = entity;
            Entity.Marker = marker;
            Entity.SetModel(this);
        }

        private void InitButton()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button
                .onClick
                .AddListener(OnClick);
        }

        private void OnClick()
        {
            SystemManager.Instance.ExecuteSystem<ButtonSystem>(Entity);
        }
    }
}