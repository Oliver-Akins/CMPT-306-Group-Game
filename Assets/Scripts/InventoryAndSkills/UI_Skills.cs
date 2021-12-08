using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class UI_Skills : MonoBehaviour{
    private SkillLevels skillLevels;
    public Transform StunSkillUI;
    public Transform PiercingSkillUI;
    public Transform DashSkillUI;
    public Transform MultiplySkillUI;

    void Start(){
        StunSkillUI.GetComponent<Button_UI>().MouseOverOnceFunc = () =>{
            Tooltip.ShowTooltip_Static("Makes your melee attacks stun your enemies; " +
            "stun duration increases by .25 seconds with each level");
        };
        StunSkillUI.GetComponent<Button_UI>().MouseOutOnceFunc = () => {
            Tooltip.HideTooltip_Static();
        };
        StunSkillUI.GetComponent<Button_UI>().ClickFunc = () => {
            skillLevels.BuyStat("Stun");
            RefreshSkillLevels();
        };

        PiercingSkillUI.GetComponent<Button_UI>().MouseOverOnceFunc = () =>{
             Tooltip.ShowTooltip_Static("Makes your projectiles peirce through enemies; " +
             "how many times they can peirces increase by 1 for each level");
        };
        PiercingSkillUI.GetComponent<Button_UI>().MouseOutOnceFunc = () => {
            Tooltip.HideTooltip_Static();
        };
        PiercingSkillUI.GetComponent<Button_UI>().ClickFunc = () => {
            skillLevels.BuyStat("Piercing");
            RefreshSkillLevels();
        };

        DashSkillUI.GetComponent<Button_UI>().MouseOverOnceFunc = () => {
            Tooltip.ShowTooltip_Static("Allows you to dash in the direction of the mouse position; " +
            "Has a 3 second cool down, each level decreases the cooldown period");
        };
        DashSkillUI.GetComponent<Button_UI>().MouseOutOnceFunc = () => {
            Tooltip.HideTooltip_Static();
        };
        DashSkillUI.GetComponent<Button_UI>().ClickFunc = () => {
            skillLevels.BuyStat("Dash");
            RefreshSkillLevels();
        };

        MultiplySkillUI.GetComponent<Button_UI>().MouseOverOnceFunc = () => {
            Tooltip.ShowTooltip_Static("You now throw multiple projectiles at once; " +
            "each level increases projectile multiplier by 1");
        };
        MultiplySkillUI.GetComponent<Button_UI>().MouseOutOnceFunc = () => {
            Tooltip.HideTooltip_Static();
        };
        MultiplySkillUI.GetComponent<Button_UI>().ClickFunc = () => {
            skillLevels.BuyStat("Multiply");
            RefreshSkillLevels();
        };
    } 

    public void RefreshSkillLevels(){
        Dictionary<string, int> skills = skillLevels.getSkills();
        
        TextMeshProUGUI mesh1 = StunSkillUI.transform.Find("SkillUpgradeAmount").GetComponent<TextMeshProUGUI>();
        mesh1.SetText(skills["Stun"].ToString());

        TextMeshProUGUI mesh2 = PiercingSkillUI.transform.Find("SkillUpgradeAmount").GetComponent<TextMeshProUGUI>();
        mesh2.SetText(skills["Piercing"].ToString());

        TextMeshProUGUI mesh3 = DashSkillUI.transform.Find("SkillUpgradeAmount").GetComponent<TextMeshProUGUI>();
        mesh3.SetText(skills["Dash"].ToString());

        TextMeshProUGUI mesh4 = MultiplySkillUI.transform.Find("SkillUpgradeAmount").GetComponent<TextMeshProUGUI>();
        mesh4.SetText(skills["Multiply"].ToString());

    }

    public void setSkillLevelsObject(SkillLevels skillLevels){
        this.skillLevels = skillLevels;
        RefreshSkillLevels();
    }
}
