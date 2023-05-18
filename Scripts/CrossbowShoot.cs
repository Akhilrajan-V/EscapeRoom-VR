using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class CrossbowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;
        private bool isgrabbed = false;
        public float shotpower = 100f;



        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        public void shootRay()
        {
            if(isgrabbed)
            {
                // RaycastHit hit;  
                // if (Physics.Raycast(arrowLocation.position,arrowLocation.TransformDirection(Vector3.forward), out hit))//, range))
                // {
                //     GameObject laser = GameObject.Instantiate(m_shotPrefab, arrowLocation.position, arrowLocation.rotation) as GameObject;
                //     laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                //     GameObject.Destroy(laser, 2f);

                // }
                Instantiate(arrowPrefab,arrowLocation.position,arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*shotpower);
            }
        }

        public void is_Grabbed()
        {
            isgrabbed = true;
        }

        public void not_Grabbed()
        {
            isgrabbed = false;
        }
    }
}
