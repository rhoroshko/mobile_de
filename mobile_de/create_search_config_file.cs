using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobile_de
{
    public partial class create_search_config_file : Form
    {
        Cars cars = new Cars();

        string make_model_version_make_1;
        string make_model_version_make_2;
        string make_model_version_make_3;

        string make_model_version_eliminate_make_1;
        string make_model_version_eliminate_make_2;
        string make_model_version_eliminate_make_3;


        public create_search_config_file()
        {
            InitializeComponent();

            initialize_make();
            initialize_number_of_doors();
            initialize_vehicle_color();
            initialize_country();
            initialize_airbags();
            initialize_ad_online_since();
            initialize_commercial_export_import();
            initialize_vat();
            initialize_emission_class();
            initialize_emission_sticker();
            initialize_damaged_vehicles();
            initialize_number_of_vehicle_owners();
            initialize_hu_valid_at_least_until_in_month();
            initialize_approved_used_programme();
        }

        public void create_search_config_file_Load(object sender, EventArgs e)
        {

        }

        private void search_config_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }


        //condition
        private void condition_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void condition_clear_button_Click(object sender, EventArgs e)
        {
            clear_condition();
        }

        private void condition_used_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void condition_new_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        //make_model_version
        private void make_model_version_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void make_model_version_clear_button_Click(object sender, EventArgs e)
        {
            clear_make_model_version();
        }

        private void make_model_version_make_1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_make_1 = make_model_version_make_1_comboBox.SelectedItem.ToString();

            make_model_version_model_1_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_make_1))
            {
                make_model_version_model_1_comboBox.Items.Add(model);
            }

            make_model_version_model_1_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_model_1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_version_1_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_make_2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_make_2 = make_model_version_make_2_comboBox.SelectedItem.ToString();

            make_model_version_model_2_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_make_2))
            {
                make_model_version_model_2_comboBox.Items.Add(model);
            }

            make_model_version_model_2_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_model_2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_version_2_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_make_3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_make_3 = make_model_version_make_3_comboBox.SelectedItem.ToString();

            make_model_version_model_3_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_make_3))
            {
                make_model_version_model_3_comboBox.Items.Add(model);
            }

            make_model_version_model_3_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_model_3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_version_3_textBox_TextChanged(object sender, EventArgs e)
        {

        }


        //make_model_version_eliminate
        private void make_model_version_eliminate_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void make_model_version_eliminate_clear_button_Click(object sender, EventArgs e)
        {
            clear_make_model_version_eliminate();
        }

        private void make_model_version_eliminate_make_1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_eliminate_make_1 = make_model_version_eliminate_make_1_comboBox.SelectedItem.ToString();

            make_model_version_eliminate_model_1_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_eliminate_make_1))
            {
                make_model_version_eliminate_model_1_comboBox.Items.Add(model);
            }

            make_model_version_eliminate_model_1_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_eliminate_model_1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void make_model_version_eliminate_make_2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_eliminate_make_2 = make_model_version_eliminate_make_2_comboBox.SelectedItem.ToString();

            make_model_version_eliminate_model_2_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_eliminate_make_2))
            {
                make_model_version_eliminate_model_2_comboBox.Items.Add(model);
            }

            make_model_version_eliminate_model_2_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_eliminate_model_2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            make_model_version_eliminate_make_3 = make_model_version_eliminate_make_3_comboBox.SelectedItem.ToString();

            make_model_version_eliminate_model_3_comboBox.Items.Clear();

            foreach (string model in cars.GetMakeModels(make_model_version_eliminate_make_3))
            {
                make_model_version_eliminate_model_3_comboBox.Items.Add(model);
            }

            make_model_version_eliminate_model_3_comboBox.SelectedIndex = 0;
        }

        private void make_model_version_eliminate_model_3_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }


        //vehicle_type
        private void vehicle_type_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void vehicle_type_clear_button_Click(object sender, EventArgs e)
        {
            clear_vehicle_type();
        }

        private void vehicle_type_suv_off_road_vehicle_pickup_truck_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_cabriolet_roadster_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_small_car_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_van_minibus_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_sedan_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_sports_car_coupe_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_kombi_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_other_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_type_number_of_seats_from_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void vehicle_type_number_of_seats_to_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void vehicle_type_number_of_doors_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //vehicle_search
        private void vehicle_search_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void vehicle_search_clear_button_Click(object sender, EventArgs e)
        {
            clear_vehicle_search();
        }

        private void vehicle_search_first_registration_year_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_first_registration_year_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_kilometer_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_kilometer_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_price_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_price_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_power_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_search_power_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        string vehicle_search_color_checkBoxComboBox_previous_text = String.Empty;

        private void vehicle_search_color_checkBoxComboBox_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (vehicle_search_color_checkBoxComboBox_previous_text == String.Empty)
            {
                vehicle_search_color_checkBoxComboBox_previous_text = vehicle_search_color_checkBoxComboBox.Text;
            }
            else if (vehicle_search_color_checkBoxComboBox.CheckBoxItems[0].Checked == true
                && !vehicle_search_color_checkBoxComboBox_previous_text.Contains(vehicle_search_color_checkBoxComboBox.Items[0].ToString())
                )
            {
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[1].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[2].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[3].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[4].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[5].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[6].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[7].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[8].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[9].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[10].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[11].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[12].Checked = false;
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[13].Checked = false;
                vehicle_search_color_checkBoxComboBox_previous_text = vehicle_search_color_checkBoxComboBox.Text;
            }
            else
            {
                vehicle_search_color_checkBoxComboBox.CheckBoxItems[0].Checked = false;
                vehicle_search_color_checkBoxComboBox_previous_text = vehicle_search_color_checkBoxComboBox.Text;
            }
        }

        private void vehicle_search_metallic_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        //engine
        private void engine_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void engine_clear_button_Click(object sender, EventArgs e)
        {
            clear_engine();
        }

        private void engine_fuel_type_petrol_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_diesel_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_electric_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_ethanol_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_hybrid_petrol_electric_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_hybrid_diesel_electric_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_lpg_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_natural_gas_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_hydrogen_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_fuel_type_other_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_transmission_automatic_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_transmission_manual_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_transmission_semi_automatic_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void engine_cubic_capacity_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void engine_cubic_capacity_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }


        //location
        private void location_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void location_clear_button_Click(object sender, EventArgs e)
        {
            clear_location();
        }

        private void location_country_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //features
        private void features_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void features_button_Click(object sender, EventArgs e)
        {
            clear_features();
        }

        private void features_air_conditioning_do_not_care_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_air_conditioning_no_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_air_conditioning_manual_or_automatic_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_air_conditioning_automatic_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_bluetooth_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_cd_player_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_isofix_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_mp3_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_rain_sensor_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_on_board_computer_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_seat_ventilation_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_auxiliary_heating_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_voice_control_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_cruise_control_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_sunroof_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_multifunction_steering_wheel_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_navigation_system_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_electric_heated_seats_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_leather_steering_wheel_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_head_up_display_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_start_stop_system_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_radio_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_central_locking_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_ski_bag_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_electric_seat_adjustment_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_electric_windows_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_features_electric_side_mirror_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_abs_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_esp_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_adaptive_cornering_lighting_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_adaptive_cruise_control_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_light_sensor_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_daytime_running_lights_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_immobilizer_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_xenon_headlights_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_four_wheel_drive_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_traction_control_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_fog_lamp_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_led_headlights_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_keyless_central_locking_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_emergency_brake_assist_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_blind_spot_assist_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_security_lane_change_assist_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_airbags_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void features_parking_sensors_rear_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_parking_sensors_front_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_parking_sensors_camera_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_parking_sensors_features_steering_systems_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_sports_suspension_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_sports_seats_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_sports_package_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_roof_rack_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_alloy_wheels_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_panoramic_roof_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_disabled_accessible_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_huck_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_extras_taxi_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_full_leather_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_part_leather_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_cloth_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_velour_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_alcantara_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_material_other_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_colour_black_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_colour_grey_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_colour_beige_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_colour_brown_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void features_interior_colour_other_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        //offer_details
        private void offer_details_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void offer_details_clear_button_Click(object sender, EventArgs e)
        {
            clear_offer_details();
        }

        private void offer_details_ad_online_since_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_ads_with_pictures_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_ads_with_video_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_discount_offers_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_vendor_do_not_care_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_vendor_private_seller_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_vendor_dealer_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_vendor_company_vehicles_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_commercial_export_import_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void offer_details_vat_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //environment
        private void environment_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void environment_clear_button_Click(object sender, EventArgs e)
        {
            clear_environment();
        }

        private void environment_fuel_consumption_from_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void environment_fuel_consumption_to_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void environment_emission_class_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void environment_emission_sticker_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void environment_particulate_filter_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        //vehicle_history
        private void vehicle_history_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void vehicle_history_clear_button_Click(object sender, EventArgs e)
        {
            clear_vehicle_history();
        }

        private void vehicle_history_warranty_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_non_smoker_vehicle_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_full_service_history_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_damaged_vehicles_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_number_of_vehicle_owners_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_hu_valid_at_least_until_in_month_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_approved_used_programme_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_ready_for_use_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_vehicle_type_demonstration_vehicle_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_vehicle_type_classic_vehicle_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_vehicle_type_pre_registration_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vehicle_history_vehicle_type_employees_car_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        //clear functions
        private void clear_condition()
        {
            condition_used_checkBox.Checked = false;
            condition_new_checkBox.Checked = false;
        }

        private void clear_make_model_version()
        {
            make_model_version_make_1_comboBox.SelectedIndex = 0;
            make_model_version_model_1_comboBox.SelectedIndex = 0;
            make_model_version_version_1_textBox.Text = String.Empty;

            make_model_version_make_2_comboBox.SelectedIndex = 0;
            make_model_version_model_2_comboBox.SelectedIndex = 0;
            make_model_version_version_2_textBox.Text = String.Empty;

            make_model_version_make_3_comboBox.SelectedIndex = 0;
            make_model_version_model_3_comboBox.SelectedIndex = 0;
            make_model_version_version_3_textBox.Text = String.Empty;
        }

        private void clear_make_model_version_eliminate()
        {
            make_model_version_eliminate_make_1_comboBox.SelectedIndex = 0;
            make_model_version_eliminate_model_1_comboBox.SelectedIndex = 0;

            make_model_version_eliminate_make_2_comboBox.SelectedIndex = 0;
            make_model_version_eliminate_model_2_comboBox.SelectedIndex = 0;

            make_model_version_eliminate_make_3_comboBox.SelectedIndex = 0;
            make_model_version_eliminate_model_3_comboBox.SelectedIndex = 0;
        }

        private void clear_vehicle_type()
        {
            vehicle_type_suv_off_road_vehicle_pickup_truck_checkBox.Checked = false;
            vehicle_type_cabriolet_roadster_checkBox.Checked = false;
            vehicle_type_small_car_checkBox.Checked = false;
            vehicle_type_van_minibus_checkBox.Checked = false;
            vehicle_type_sedan_checkBox.Checked = false;
            vehicle_type_sports_car_coupe_checkBox.Checked = false;
            vehicle_type_kombi_checkBox.Checked = false;
            vehicle_type_other_checkBox.Checked = false;
            vehicle_type_number_of_seats_from_textBox.Text = String.Empty;
            vehicle_type_number_of_seats_to_textBox.Text = String.Empty;
            vehicle_type_number_of_doors_comboBox.SelectedIndex = 0;
        }

        private void clear_vehicle_search()
        {
            vehicle_search_first_registration_year_from_textBox.Text = String.Empty;
            vehicle_search_first_registration_year_to_textBox.Text = String.Empty;
            vehicle_search_kilometer_from_textBox.Text = String.Empty;
            vehicle_search_kilometer_to_textBox.Text = String.Empty;
            vehicle_search_price_from_textBox.Text = String.Empty;
            vehicle_search_price_to_textBox.Text = String.Empty;
            vehicle_search_power_from_textBox.Text = String.Empty;
            vehicle_search_power_to_textBox.Text = String.Empty;
            vehicle_search_ps_radioButton.Checked = true;
            vehicle_search_color_checkBoxComboBox.CheckBoxItems[0].Checked = true;
            vehicle_search_metallic_checkBox.Checked = false;
        }

        private void clear_engine()
        {
            engine_fuel_type_petrol_checkBox.Checked = false;
            engine_fuel_type_diesel_checkBox.Checked = false;
            engine_fuel_type_electric_checkBox.Checked = false;
            engine_fuel_type_ethanol_checkBox.Checked = false;
            engine_fuel_type_hybrid_petrol_electric_checkBox.Checked = false;
            engine_fuel_type_hybrid_diesel_electric_checkBox.Checked = false;
            engine_fuel_type_lpg_checkBox.Checked = false;
            engine_fuel_type_natural_gas_checkBox.Checked = false;
            engine_fuel_type_hydrogen_checkBox.Checked = false;
            engine_fuel_type_other_checkBox.Checked = false;
            engine_transmission_manual_checkBox.Checked = false;
            engine_transmission_semi_automatic_checkBox.Checked = false;
            engine_transmission_automatic_checkBox.Checked = false;
            engine_cubic_capacity_from_textBox.Text = String.Empty;
            engine_cubic_capacity_to_textBox.Text = String.Empty;
        }

        private void clear_location()
        {

        }

        private void clear_features()
        {
            features_air_conditioning_do_not_care_radioButton.Checked = true;
            features_interior_features_bluetooth_checkBox.Checked = false;
            features_interior_features_cd_player_checkBox.Checked = false;
            features_interior_features_isofix_checkBox.Checked = false;
            features_interior_features_mp3_checkBox.Checked = false;
            features_interior_features_rain_sensor_checkBox.Checked = false;
            features_interior_features_on_board_computer_checkBox.Checked = false;
            features_interior_features_seat_ventilation_checkBox.Checked = false;
            features_interior_features_auxiliary_heating_checkBox.Checked = false;
            features_interior_features_voice_control_checkBox.Checked = false;
            features_interior_features_cruise_control_checkBox.Checked = false;
            features_interior_features_sunroof_checkBox.Checked = false;
            features_interior_features_multifunction_steering_wheel_checkBox.Checked = false;
            features_interior_features_navigation_system_checkBox.Checked = false;
            features_interior_features_electric_heated_seats_checkBox.Checked = false;
            features_interior_features_leather_steering_wheel_checkBox.Checked = false;
            features_interior_features_head_up_display_checkBox.Checked = false;
            features_interior_features_start_stop_system_checkBox.Checked = false;
            features_interior_features_radio_checkBox.Checked = false;
            features_interior_features_central_locking_checkBox.Checked = false;
            features_interior_features_ski_bag_checkBox.Checked = false;
            features_interior_features_electric_seat_adjustment_checkBox.Checked = false;
            features_interior_features_electric_windows_checkBox.Checked = false;
            features_interior_features_electric_side_mirror_checkBox.Checked = false;
            features_security_abs_checkBox.Checked = false;
            features_security_esp_checkBox.Checked = false;
            features_security_adaptive_cornering_lighting_checkBox.Checked = false;
            features_security_adaptive_cruise_control_checkBox.Checked = false;
            features_security_light_sensor_checkBox.Checked = false;
            features_security_daytime_running_lights_checkBox.Checked = false;
            features_security_immobilizer_checkBox.Checked = false;
            features_security_xenon_headlights_checkBox.Checked = false;
            features_security_four_wheel_drive_checkBox.Checked = false;
            features_security_traction_control_checkBox.Checked = false;
            features_security_fog_lamp_checkBox.Checked = false;
            features_security_led_headlights_checkBox.Checked = false;
            features_security_keyless_central_locking_checkBox.Checked = false;
            features_security_emergency_brake_assist_checkBox.Checked = false;
            features_security_blind_spot_assist_checkBox.Checked = false;
            features_security_lane_change_assist_checkBox.Checked = false;
            features_airbags_comboBox.SelectedIndex = 0;
            features_parking_sensors_rear_checkBox.Checked = false;
            features_parking_sensors_front_checkBox.Checked = false;
            features_parking_sensors_camera_checkBox.Checked = false;
            features_parking_sensors_features_steering_systems_checkBox.Checked = false;
            features_sports_suspension_checkBox.Checked = false;
            features_sports_seats_checkBox.Checked = false;
            features_sports_package_checkBox.Checked = false;
            features_extras_roof_rack_checkBox.Checked = false;
            features_extras_alloy_wheels_checkBox.Checked = false;
            features_extras_panoramic_roof_checkBox.Checked = false;
            features_extras_disabled_accessible_checkBox.Checked = false;
            features_extras_huck_checkBox.Checked = false;
            features_extras_taxi_checkBox.Checked = false;
            features_interior_material_full_leather_checkBox.Checked = false;
            features_interior_material_part_leather_checkBox.Checked = false;
            features_interior_material_cloth_checkBox.Checked = false;
            features_interior_material_velour_checkBox.Checked = false;
            features_interior_material_alcantara_checkBox.Checked = false;
            features_interior_material_other_checkBox.Checked = false;
            features_interior_colour_black_checkBox.Checked = false;
            features_interior_colour_grey_checkBox.Checked = false;
            features_interior_colour_beige_checkBox.Checked = false;
            features_interior_colour_brown_checkBox.Checked = false;
            features_interior_colour_other_checkBox.Checked = false;
        }

        private void clear_offer_details()
        {
            offer_details_ad_online_since_comboBox.SelectedIndex = 0;
            offer_details_ads_with_pictures_checkBox.Checked = false;
            offer_details_ads_with_video_checkBox.Checked = false;
            offer_details_discount_offers_checkBox.Checked = false;
            offer_details_vendor_do_not_care_radioButton.Checked = true;
            offer_details_commercial_export_import_comboBox.SelectedIndex = 0;
            offer_details_vat_comboBox.SelectedIndex = 0;
        }

        private void clear_environment()
        {
            environment_fuel_consumption_from_textBox.Text = String.Empty;
            environment_fuel_consumption_to_textBox.Text = String.Empty;
            environment_emission_class_comboBox.SelectedIndex = 0;
            environment_emission_sticker_comboBox.SelectedIndex = 0;
            environment_particulate_filter_checkBox.Checked = false;
        }

        private void clear_vehicle_history()
        {
            vehicle_history_warranty_checkBox.Checked = false;
            vehicle_history_non_smoker_vehicle_checkBox.Checked = false;
            vehicle_history_full_service_history_checkBox.Checked = false;
            vehicle_history_damaged_vehicles_comboBox.SelectedIndex = 0;
            vehicle_history_number_of_vehicle_owners_comboBox.SelectedIndex = 0;
            vehicle_history_hu_valid_at_least_until_in_month_comboBox.SelectedIndex = 0;
            vehicle_history_approved_used_programme_comboBox.SelectedIndex = 0;
            vehicle_history_ready_for_use_checkBox.Checked = false;
            vehicle_history_vehicle_type_demonstration_vehicle_checkBox.Checked = false;
            vehicle_history_vehicle_type_classic_vehicle_checkBox.Checked = false;
            vehicle_history_vehicle_type_pre_registration_checkBox.Checked = false;
            vehicle_history_vehicle_type_employees_car_checkBox.Checked = false;
        }


        //initialize functions
        private void initialize_make()
        {
            cars.LoadJson();
            List<string> makes = cars.GetMakes();

            foreach (string make in makes)
            {
                make_model_version_make_1_comboBox.Items.Add(make);
                make_model_version_make_2_comboBox.Items.Add(make);
                make_model_version_make_3_comboBox.Items.Add(make);

                make_model_version_eliminate_make_1_comboBox.Items.Add(make);
                make_model_version_eliminate_make_2_comboBox.Items.Add(make);
                make_model_version_eliminate_make_3_comboBox.Items.Add(make);
            }
            make_model_version_make_1_comboBox.SelectedIndex = 0;
            make_model_version_make_2_comboBox.SelectedIndex = 0;
            make_model_version_make_3_comboBox.SelectedIndex = 0;

            make_model_version_eliminate_make_1_comboBox.SelectedIndex = 0;
            make_model_version_eliminate_make_2_comboBox.SelectedIndex = 0;
            make_model_version_eliminate_make_3_comboBox.SelectedIndex = 0;
        }

        private void initialize_number_of_doors()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\number_of_doors.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_type_number_of_doors_comboBox.Items.Add(line);
            }
            vehicle_type_number_of_doors_comboBox.SelectedIndex = 0;

        }

        private void initialize_vehicle_color()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\vehicle_color.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_search_color_checkBoxComboBox.Items.Add(line);
            }
            vehicle_search_color_checkBoxComboBox.CheckBoxItems[0].Checked = true;
        }

        private void initialize_country()
        {
            location_country_comboBox.Items.Add("Германия");
            location_country_comboBox.SelectedIndex = 0;
        }

        private void initialize_airbags()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\airbags.txt")).ToList();

            foreach (string line in lines)
            {
                features_airbags_comboBox.Items.Add(line);
            }
            features_airbags_comboBox.SelectedIndex = 0;
        }

        private void initialize_ad_online_since()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\ad_online_since.txt")).ToList();

            foreach (string line in lines)
            {
                offer_details_ad_online_since_comboBox.Items.Add(line);
            }
            offer_details_ad_online_since_comboBox.SelectedIndex = 0;
        }

        private void initialize_commercial_export_import()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\commercial_export_import.txt")).ToList();

            foreach (string line in lines)
            {
                offer_details_commercial_export_import_comboBox.Items.Add(line);
            }
            offer_details_commercial_export_import_comboBox.SelectedIndex = 0;
        }

        private void initialize_vat()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\vat.txt")).ToList();

            foreach (string line in lines)
            {
                offer_details_vat_comboBox.Items.Add(line);
            }
            offer_details_vat_comboBox.SelectedIndex = 0;
        }

        private void initialize_emission_class()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\emission_class.txt")).ToList();

            foreach (string line in lines)
            {
                environment_emission_class_comboBox.Items.Add(line);
            }
            environment_emission_class_comboBox.SelectedIndex = 0;
        }

        private void initialize_emission_sticker()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\emission_sticker.txt")).ToList();

            foreach (string line in lines)
            {
                environment_emission_sticker_comboBox.Items.Add(line);
            }
            environment_emission_sticker_comboBox.SelectedIndex = 0;
        }

        private void initialize_damaged_vehicles()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\damaged_vehicles.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_history_damaged_vehicles_comboBox.Items.Add(line);
            }
            vehicle_history_damaged_vehicles_comboBox.SelectedIndex = 0;
        }

        private void initialize_number_of_vehicle_owners()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\number_of_vehicle_owners.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_history_number_of_vehicle_owners_comboBox.Items.Add(line);
            }
            vehicle_history_number_of_vehicle_owners_comboBox.SelectedIndex = 0;
        }

        private void initialize_hu_valid_at_least_until_in_month()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\hu_valid_at_least_until_in_month.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_history_hu_valid_at_least_until_in_month_comboBox.Items.Add(line);
            }
            vehicle_history_hu_valid_at_least_until_in_month_comboBox.SelectedIndex = 0;
        }

        private void initialize_approved_used_programme()
        {
            List<string> lines = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\approved_used_programme.txt")).ToList();

            foreach (string line in lines)
            {
                vehicle_history_approved_used_programme_comboBox.Items.Add(line);
            }
            vehicle_history_approved_used_programme_comboBox.SelectedIndex = 0;
        }


        //validate
        private void validate_numeric_values(object sender, KeyPressEventArgs e)
        {
            if (
                e.Handled = !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Enter
                && e.KeyChar != (char)Keys.Delete
                )
            {

            }
        }

        private Boolean validate_vehicle_type_number_of_seats()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (vehicle_type_number_of_seats_from_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_type_number_of_seats_from_textBox.Text) < 2
                 || Int32.Parse(vehicle_type_number_of_seats_from_textBox.Text) > 7
                )
                {
                    wrong_data = true;
                }
            }

            if (vehicle_type_number_of_seats_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_type_number_of_seats_to_textBox.Text) < 2
                 || Int32.Parse(vehicle_type_number_of_seats_to_textBox.Text) > 7
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение количиства сидений должно быть между 2 и 7 или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_vehicle_search_first_registration_year()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (vehicle_search_first_registration_year_from_textBox.Text != "")
            {                
                if (
                    Int32.Parse(vehicle_search_first_registration_year_from_textBox.Text) < 1900
                 || Int32.Parse(vehicle_search_first_registration_year_from_textBox.Text) > DateTime.Now.Year
                )
                {
                    wrong_data = true;
                }
            }

            if (vehicle_search_first_registration_year_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_search_first_registration_year_to_textBox.Text) < 1900
                 || Int32.Parse(vehicle_search_first_registration_year_to_textBox.Text) > DateTime.Now.Year
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение первой регистрации должно быть между 1900 и сегодня или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_vehicle_search_kilometer()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (vehicle_search_kilometer_from_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_search_kilometer_from_textBox.Text) < 5000
                 || Int32.Parse(vehicle_search_kilometer_from_textBox.Text) > 200000
                )
                {
                    wrong_data = true;
                }
            }

            if (vehicle_search_kilometer_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_search_kilometer_to_textBox.Text) < 5000
                 || Int32.Parse(vehicle_search_kilometer_to_textBox.Text) > 200000
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение пробега должно быть между 5000 и 200000 или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_vehicle_search_price()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (vehicle_search_price_from_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_search_price_from_textBox.Text) < 500
                 || Int32.Parse(vehicle_search_price_from_textBox.Text) > 100000
                )
                {
                    wrong_data = true;
                }
            }

            if (vehicle_search_price_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(vehicle_search_price_to_textBox.Text) < 500
                 || Int32.Parse(vehicle_search_price_to_textBox.Text) > 100000
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение цены должно быть между 500 и 100000 или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_vehicle_search_power()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (vehicle_search_power_from_textBox.Text != "")
            {
                if (
                    (
                    vehicle_search_ps_radioButton.Checked == true
                    && (
                            Int32.Parse(vehicle_search_power_from_textBox.Text) < 34
                         || Int32.Parse(vehicle_search_power_from_textBox.Text) > 454
                        )
                    )
                    ||
                    (
                    vehicle_search_kw_radioButton.Checked == true
                    && (
                            Int32.Parse(vehicle_search_power_from_textBox.Text) < 25
                         || Int32.Parse(vehicle_search_power_from_textBox.Text) > 334
                        )
                    )
                )
                {
                    wrong_data = true;
                }
            }

            if (vehicle_search_power_to_textBox.Text != "")
            {
                if (
                    (
                    vehicle_search_ps_radioButton.Checked == true
                    && (
                            Int32.Parse(vehicle_search_power_to_textBox.Text) < 34
                         || Int32.Parse(vehicle_search_power_to_textBox.Text) > 454
                        )
                    )
                    ||
                    (
                    vehicle_search_kw_radioButton.Checked == true
                    && (
                            Int32.Parse(vehicle_search_power_to_textBox.Text) < 25
                         || Int32.Parse(vehicle_search_power_to_textBox.Text) > 334
                        )
                    )
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show(@"Значение мощьности должно быть пустым или:
между 34 и 454 для л.с.
между 25 и 334 для кВт.");
            }
            
            return wrong_data;
        }

        private Boolean validate_engine_cubic_capacity()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (engine_cubic_capacity_from_textBox.Text != "")
            {
                if (
                    Int32.Parse(engine_cubic_capacity_from_textBox.Text) < 1000
                 || Int32.Parse(engine_cubic_capacity_from_textBox.Text) > 9000
                )
                {
                    wrong_data = true;
                }
            }

            if (engine_cubic_capacity_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(engine_cubic_capacity_to_textBox.Text) < 1000
                 || Int32.Parse(engine_cubic_capacity_to_textBox.Text) > 9000
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение рабочего объема должно быть между 1000 и 9000 или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_fuel_consumption()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (environment_fuel_consumption_from_textBox.Text != "")
            {
                if (
                    Int32.Parse(environment_fuel_consumption_from_textBox.Text) < 3
                 || Int32.Parse(environment_fuel_consumption_from_textBox.Text) > 15
                )
                {
                    wrong_data = true;
                }
            }

            if (environment_fuel_consumption_to_textBox.Text != "")
            {
                if (
                    Int32.Parse(environment_fuel_consumption_to_textBox.Text) < 3
                 || Int32.Parse(environment_fuel_consumption_to_textBox.Text) > 15
                )
                {
                    wrong_data = true;
                }
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение расхода топлива должно быть между 3 и 15 или пустым.");
            }

            return wrong_data;
        }

        private Boolean validate_all()
        {
            Boolean wrong_data;
            wrong_data = false;
            if (
                   validate_vehicle_type_number_of_seats() == true
                || validate_vehicle_search_first_registration_year() == true
                || validate_vehicle_search_kilometer() == true
                || validate_vehicle_search_price() == true
                || validate_vehicle_search_power() == true
                || validate_engine_cubic_capacity() == true
                || validate_fuel_consumption() == true
                )
            {
                wrong_data = true;
            }

            return wrong_data;
        }


        //load
        private void load_search_config_file_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO
            }
        }


        //save
        private void save_search_config_file_button_Click(object sender, EventArgs e)
        {
            Boolean wrong_data = validate_all();

            if (wrong_data == true)
            {
                return;
            }


            string power_unit = "л.с.";
            if (vehicle_search_kw_radioButton.Checked == true)
            {
                power_unit = "кВт";
            }

            string vehicle_search_color = $"\"{vehicle_search_color_checkBoxComboBox.Items[0].ToString()}\"";
            if (vehicle_search_color_checkBoxComboBox.Text != String.Empty)
            {
                vehicle_search_color = $"\"{vehicle_search_color_checkBoxComboBox.Text.Replace(", ", $"\",{Environment.NewLine}            \"")}\"";
            }

            string air_conditioning = "Не важно";
            if (features_air_conditioning_no_radioButton.Checked == true)
            {
                air_conditioning = "Без климатической установки";
            }
            else if (features_air_conditioning_manual_or_automatic_radioButton.Checked == true)
            {
                air_conditioning = "Ручное или автоматическое управление климатом";
            }
            else if (features_air_conditioning_automatic_radioButton.Checked == true)
            {
                air_conditioning = "Автоматический кондиционер";
            }

            string offer_details_vendor = "Не важно";
            if (offer_details_vendor_private_seller_radioButton.Checked == true)
            {
                offer_details_vendor = "Частный продавец";
            }
            else if (offer_details_vendor_dealer_radioButton.Checked == true)
            {
                offer_details_vendor = "Дилер";
            }
            else if (offer_details_vendor_company_vehicles_radioButton.Checked == true)
            {
                offer_details_vendor = "Корпоративные автомобили";
            }

            string search_config = ""
+ $"{{"
+ $"{Environment.NewLine}    \"Расширенный поиск: автомобили — новые или подержанные\": {{"
+ $"{Environment.NewLine}        \"Подержанные автомобили\": {condition_used_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Только новые автомобили\": {condition_new_checkBox.Checked}"
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Основные сведения об автомобиле\": ["
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_make_1_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_model_1_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Описание модели\": \"{make_model_version_version_1_textBox.Text}\""
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_make_2_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_model_2_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Описание модели\": \"{make_model_version_version_2_textBox.Text}\""
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_make_3_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_model_3_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Описание модели\": \"{make_model_version_version_3_textBox.Text}\""
+ $"{Environment.NewLine}        }}"
+ $"{Environment.NewLine}    ],"
+ $"{Environment.NewLine}    \"Исключить транспортные средства из результатов поиска\": ["
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_eliminate_make_1_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_eliminate_model_1_comboBox.Text}\","
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_eliminate_make_2_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_eliminate_model_2_comboBox.Text}\","
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        {{"
+ $"{Environment.NewLine}            \"Марка\": \"{make_model_version_eliminate_make_3_comboBox.Text}\","
+ $"{Environment.NewLine}            \"Модель\": \"{make_model_version_eliminate_model_3_comboBox.Text}\","
+ $"{Environment.NewLine}        }}"
+ $"{Environment.NewLine}    ],"
+ $"{Environment.NewLine}    \"Типы транспортных средств\": {{"
+ $"{Environment.NewLine}        \"SUV / Off-road Vehicle / Pickup Truck\": {vehicle_type_suv_off_road_vehicle_pickup_truck_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Кабриолет / родстер\": {vehicle_type_cabriolet_roadster_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Малолитражный автомобиль\": {vehicle_type_small_car_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Минивэн / микроавтобус\": {vehicle_type_van_minibus_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Седан\": {vehicle_type_sedan_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Спортивный автомобиль/купе\": {vehicle_type_sports_car_coupe_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Универсал\": {vehicle_type_kombi_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Иное\": {vehicle_type_other_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Количество сидений от\": \"{vehicle_type_number_of_seats_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Количество сидений до\": \"{vehicle_type_number_of_seats_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Количество дверей\": \"{vehicle_type_number_of_doors_comboBox.Text}\""
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Поиск транспортного средства\": {{"
+ $"{Environment.NewLine}        \"Первая регистрация от\": \"{vehicle_search_first_registration_year_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Первая регистрация до\": \"{vehicle_search_first_registration_year_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Пробег от\": \"{vehicle_search_kilometer_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Пробег до\": \"{vehicle_search_kilometer_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Цена от\": \"{vehicle_search_price_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Цена до\": \"{vehicle_search_price_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Мощность от\": \"{vehicle_search_power_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Мощность до\": \"{vehicle_search_power_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Мощность единицы измерения\": \"{power_unit}\","
+ $"{Environment.NewLine}        \"Цвет навесного оборудования\": ["
+ $"{Environment.NewLine}            {vehicle_search_color}"
+ $"{Environment.NewLine}        ],"
+ $"{Environment.NewLine}        \"Металлик\": {vehicle_search_metallic_checkBox.Checked}"
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Двигатель\": {{"
+ $"{Environment.NewLine}        \"Вид топлива\": {{"
+ $"{Environment.NewLine}            \"Бензиновый\": {engine_fuel_type_petrol_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Дизельный\": {engine_fuel_type_diesel_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Электрический\": {engine_fuel_type_electric_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Этанол (FFV, E85 и т.п.)\": {engine_fuel_type_ethanol_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Гибридный (бензин/электричество)\": {engine_fuel_type_hybrid_petrol_electric_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Гибрид (дизельный / электрический)\": {engine_fuel_type_hybrid_diesel_electric_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Сжиженный нефтяной газ\": {engine_fuel_type_lpg_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Природный газ\": {engine_fuel_type_natural_gas_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Водород\": {engine_fuel_type_hydrogen_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Иное\": {engine_fuel_type_other_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Коробка передач\": {{"
+ $"{Environment.NewLine}            \"Автоматическая КП\": {engine_transmission_automatic_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Механическая коробка передач\": {engine_transmission_manual_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Полуавтоматическая КП\": {engine_transmission_semi_automatic_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Рабочий объем от\": \"{engine_cubic_capacity_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Рабочий объем до\": \"{engine_cubic_capacity_to_textBox.Text}\""
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Региональный поиск\": {{"
+ $"{Environment.NewLine}        \"Импорт автомобилей из\": ["
+ $"{Environment.NewLine}            \"{location_country_comboBox.Text}\""
+ $"{Environment.NewLine}        ]"
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Удобство и дизайн салона\": {{"
+ $"{Environment.NewLine}        \"Климатическая установка\": \"{air_conditioning}\","
+ $"{Environment.NewLine}        \"Внутреннее оформление\": {{"
+ $"{Environment.NewLine}            \"Bluetooth\": {features_interior_features_bluetooth_checkBox.Checked},"
+ $"{Environment.NewLine}            \"CD-проигрыватель\": {features_interior_features_cd_player_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Isofix (крепления детских сидений)\": {features_interior_features_isofix_checkBox.Checked},"
+ $"{Environment.NewLine}            \"MP3-интерфейс\": {features_interior_features_mp3_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Автоматический датчик дождя\": {features_interior_features_rain_sensor_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Бортовой компьютер\": {features_interior_features_on_board_computer_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Вентилируемые сиденья\": {features_interior_features_seat_ventilation_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Вспомогательный обогреватель\": {features_interior_features_auxiliary_heating_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Комплект громкой связи\": {features_interior_features_voice_control_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Круиз-контроль\": {features_interior_features_cruise_control_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Люк в крыше\": {features_interior_features_sunroof_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Многофункциональное рулевое колесо\": {features_interior_features_multifunction_steering_wheel_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Навигационная система\": {features_interior_features_navigation_system_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Подогрев сидений\": {features_interior_features_electric_heated_seats_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Рулевой механизм с усилителем\": {features_interior_features_leather_steering_wheel_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Система индикации на лобовом стекле\": {features_interior_features_head_up_display_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Стартстопная система\": {features_interior_features_start_stop_system_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Тюнер/радио\": {features_interior_features_radio_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Центральный замок\": {features_interior_features_central_locking_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Чехол для лыж\": {features_interior_features_ski_bag_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Электрическая регулировка сидений\": {features_interior_features_electric_seat_adjustment_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Электрические стеклоподъемники\": {features_interior_features_electric_windows_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Электрическое боковое зеркало\": {features_interior_features_electric_side_mirror_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Безопасность\": {{"
+ $"{Environment.NewLine}            \"ABS\": {features_security_abs_checkBox.Checked},"
+ $"{Environment.NewLine}            \"ESP\": {features_security_esp_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Адаптивное освещение поворотов\": {features_security_adaptive_cornering_lighting_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Адаптивный круиз-контроль\": {features_security_adaptive_cruise_control_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Датчик света\": {features_security_light_sensor_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Дневные ходовые огни\": {features_security_daytime_running_lights_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Иммобилайзер\": {features_security_immobilizer_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Ксеноновые фары\": {features_security_xenon_headlights_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Привод на четыре колеса\": {features_security_four_wheel_drive_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Противобуксовочная система\": {features_security_traction_control_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Противотуманная фара\": {features_security_fog_lamp_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Светодиодные фары\": {features_security_led_headlights_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Система бесключевого доступа к автомобилю\": {features_security_keyless_central_locking_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Система избежания столкновений\": {features_security_emergency_brake_assist_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Система мониторинга слепых зон\": {features_security_blind_spot_assist_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Система предупреждения о сходе с полосы движения\": {features_security_lane_change_assist_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Подушки безопасности\": \"{features_airbags_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Датчики парковки\": {{"
+ $"{Environment.NewLine}            \"Сзади\": {features_parking_sensors_rear_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Спереди\": {features_parking_sensors_front_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Камера\": {features_parking_sensors_camera_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Системы автоматического рулевого управления\": {features_parking_sensors_features_steering_systems_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Спортивные\": {{"
+ $"{Environment.NewLine}            \"Спортивная подвеска\": {features_sports_suspension_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Спортивные сиденья\": {features_sports_seats_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Спортивный пакет\": {features_sports_package_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Опции\": {{"
+ $"{Environment.NewLine}            \"Багажник на крыше\": {features_extras_roof_rack_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Колеса из легкого сплава\": {features_extras_alloy_wheels_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Стеклянная крыша для панорамного обзора\": {features_extras_panoramic_roof_checkBox.Checked},"
+ $"{Environment.NewLine}            \"С устройством для доступа инвалидов\": {features_extras_disabled_accessible_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Сцепное устройство прицепа\": {features_extras_huck_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Такси\": {features_extras_taxi_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Тип салона\": {{"
+ $"{Environment.NewLine}            \"Полностью из кожи\": {features_interior_material_full_leather_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Частично из кожи\": {features_interior_material_part_leather_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Обивка\": {features_interior_material_cloth_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Велюр\": {features_interior_material_velour_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Алькантара\": {features_interior_material_alcantara_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Другое\": {features_interior_material_other_checkBox.Checked}"
+ $"{Environment.NewLine}        }},"
+ $"{Environment.NewLine}        \"Цвет салона\": {{"
+ $"{Environment.NewLine}            \"Черный\": {features_interior_colour_black_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Серый\": {features_interior_colour_grey_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Бежевый\": {features_interior_colour_beige_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Коричневый\": {features_interior_colour_brown_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Другое\": {features_interior_colour_other_checkBox.Checked}"
+ $"{Environment.NewLine}        }}"
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Сведения о предложении\": {{"
+ $"{Environment.NewLine}        \"Объявление онлайн с\": \"{offer_details_ad_online_since_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Объявления с фото\": {offer_details_ads_with_pictures_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Объявления с видео\": {offer_details_ads_with_video_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Горячие предложения\": {offer_details_discount_offers_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Поставщик\": \"{offer_details_vendor}\","
+ $"{Environment.NewLine}        \"Только бизнес, экспорт и импорт предложения\": \"{offer_details_commercial_export_import_comboBox.Text}\","
+ $"{Environment.NewLine}        \"НДС\": \"{offer_details_vat_comboBox.Text}\""
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"Безопасность и экологичность\": {{"
+ $"{Environment.NewLine}        \"Расход топлива комбин. от\": \"{environment_fuel_consumption_from_textBox.Text}\","
+ $"{Environment.NewLine}        \"Расход топлива комбин. до\": \"{environment_fuel_consumption_to_textBox.Text}\","
+ $"{Environment.NewLine}        \"Класс экологической безопасности\": \"{environment_emission_class_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Экологическая наклейка\": \"{environment_emission_sticker_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Пылевой фильтр\": {environment_particulate_filter_checkBox.Checked}"
+ $"{Environment.NewLine}    }},"
+ $"{Environment.NewLine}    \"История транспортного средства\": {{"
+ $"{Environment.NewLine}        \"Гарантия\": {vehicle_history_warranty_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Машина некурящего водителя\": {vehicle_history_non_smoker_vehicle_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Полная история обслуживания\": {vehicle_history_full_service_history_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Поврежденные транспортные средства\": \"{vehicle_history_damaged_vehicles_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Количество предыдущих владельцев\": \"{vehicle_history_number_of_vehicle_owners_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Технический осмотр\": \"{vehicle_history_hu_valid_at_least_until_in_month_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Сертификат для продавцов\": \"{vehicle_history_approved_used_programme_comboBox.Text}\","
+ $"{Environment.NewLine}        \"Пригодно к эксплуатации\": {vehicle_history_ready_for_use_checkBox.Checked},"
+ $"{Environment.NewLine}        \"Подкатегория\": {{"
+ $"{Environment.NewLine}            \"Демонстрационное транспортное средство\": {vehicle_history_vehicle_type_demonstration_vehicle_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Олдтаймер\": {vehicle_history_vehicle_type_classic_vehicle_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Предварительная регистрация\": {vehicle_history_vehicle_type_pre_registration_checkBox.Checked},"
+ $"{Environment.NewLine}            \"Служебный автомобиль\": {vehicle_history_vehicle_type_employees_car_checkBox.Checked}"
+ $"{Environment.NewLine}        }}"
+ $"{Environment.NewLine}    }}"
+ $"{Environment.NewLine}}}";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, search_config);
            }
        }


        //clear_all
        private void clear_search_config_button_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Вы точно хотите очистить всё?",
                                    "Очистить всё",
                                    MessageBoxButtons.YesNoCancel);
            if (confirmResult == DialogResult.Yes)
            {
                clear_condition();
                clear_make_model_version();
                clear_make_model_version_eliminate();
                clear_vehicle_type();
                clear_vehicle_search();
                clear_engine();
                clear_features();
                clear_offer_details();
                clear_environment();
                clear_vehicle_history();
            }
            else
            {
            }
        }


        //create_scores_config
        private void create_scores_config_file_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_scores_config_file scores_config_form = new create_scores_config_file();
            scores_config_form.StartPosition = FormStartPosition.Manual;
            scores_config_form.Location = this.Location;
            scores_config_form.Size = this.Size;
            scores_config_form.ShowDialog();
        }


        //search_cars
        private void search_cars_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            search_cars search_cars_form = new search_cars();
            search_cars_form.StartPosition = FormStartPosition.Manual;
            search_cars_form.Location = this.Location;
            search_cars_form.Size = this.Size;
            search_cars_form.ShowDialog();
        }
    }
}
