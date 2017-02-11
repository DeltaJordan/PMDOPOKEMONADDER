using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PMDOAddPokémon
{
    public partial class PokeInfo : Form
    {
        MySqlConnection Connection = null;
        public PokeInfo(MySqlConnection conn)
        {
            InitializeComponent();
            Connection = conn;
            foreach (Control nud in Controls)
            {
                if (nud is TextBox)
                {
                    if (nud.Name.Contains("Move"))
                        nud.KeyDown += new KeyEventHandler(OnMoveEnter);
                    
                }
            }
        }

        private void OnMoveEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                switch ((sender as TextBox).Name)
                {
                    case "nudEggMove":
                        {
                            btnAddEgg_Click(sender, new EventArgs());
                        }
                        break;
                    case "nudEventMove":
                        {
                            btnAddEvent_Click(sender, new EventArgs());
                        }
                        break;
                    case "nudLvlMove":
                        {
                            btnAddLvl_Click(sender, new EventArgs());
                        }
                        break;
                    case "nudTMMove":
                        {
                            btnAddTM_Click(sender, new EventArgs());
                        }
                        break;
                    case "nudTutorMove":
                        {
                            btnAddTutor_Click(sender, new EventArgs());
                        }
                        break;
                    default:
                        throw new Exception();
                }

                (sender as TextBox).Text = "";
            }
        }

        private void nudDexNum_ValueChanged(object sender, EventArgs e)
        {
            pbPokePic.Image = PokéDex.PokeSpriteFromDex((int)nudDexNum.Value);
            tbName.Text = PokéDex.PokeName((int)nudDexNum.Value);
        }

        private void nudMaleRatio_ValueChanged(object sender, EventArgs e)
        {
            nudFemaleRatio.Value = 1000 - nudMaleRatio.Value;
        }

        private void btnAddEgg_Click(object sender, EventArgs e)
        {
            int MoveNum = 0;
            try
            {
                MoveNum = (int)((PokéDex.Moves)Enum.Parse(typeof(PokéDex.Moves), nudEggMove.Text.Replace("-", "0").Replace(" ", "_"), true));
            }
            catch
            {
                MessageBox.Show("Either this move does not exist or you spelled it wrong");
                return;
            }
            if (lbxEggMoves.Items.Contains(MoveNum) == false)
            {
                lbxEggMoves.Items.Add(MoveNum);
            }
        }

        private void lbxEggMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxEggMoves.SelectedItem != null)
            {
                delEggMove.Visible = true;
            }
            else
            {
                delEggMove.Hide();
            }
        }

        private void cbxAlolan_CheckedChanged(object sender, EventArgs e)
        {
            if (nudDexNum.Value < 7000)
            {
                nudDexNum.Value += 7000;
                nudDexNum.ReadOnly = !nudDexNum.ReadOnly;
            }
            else
            {
                nudDexNum.Value -= 7000;
                nudDexNum.ReadOnly = !nudDexNum.ReadOnly;
            }
        }

        private void delEggMove_Click(object sender, EventArgs e)
        {
            lbxEggMoves.Items.Remove(lbxEggMoves.SelectedItem);
        }

        private void lbxEventMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxEventMoves.SelectedItem != null)
            {
                delEventMove.Show();
            }
            else
            {
                delEventMove.Hide();
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            int MoveNum = 0;
            try
            {
                MoveNum = (int)((PokéDex.Moves)Enum.Parse(typeof(PokéDex.Moves), nudEventMove.Text.Replace("-", "0").Replace(" ", "_"), true));
            }
            catch
            {
                MessageBox.Show("Either this move does not exist or you spelled it wrong");
                return;
            }
            if (lbxEventMoves.Items.Contains(MoveNum) == false)
            {
                lbxEventMoves.Items.Add(MoveNum);
            }
        }

        private void lbxLevelMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxLevelMove.SelectedItem != null)
            {
                delLvlMove.Show();
            }
            else
            {
                delLvlMove.Hide();
            }
        }

        private void delEventMove_Click(object sender, EventArgs e)
        {
            lbxEventMoves.Items.Remove(lbxEventMoves.SelectedItem);
        }

        private void delLvlMove_Click(object sender, EventArgs e)
        {
            lbxLevelMove.Items.Remove(lbxLevelMove.SelectedItem);
        }

        private void btnAddLvl_Click(object sender, EventArgs e)
        {
            int MoveNum = 0;
            try
            {
                MoveNum = (int)((PokéDex.Moves)Enum.Parse(typeof(PokéDex.Moves), nudLvlMove.Text.Replace("-", "0").Replace(" ", "_"), true));
            }
            catch
            {
                MessageBox.Show("Either this move does not exist or you spelled it wrong");
                return;
            }
            if (lbxLevelMove.Items.Contains(MoveNum) == false)
            {
                lbxLevelMove.Items.Add(MoveNum);
            }
        }

        private void lbxTMMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxTMMoves.SelectedItem != null)
            {
                delTMMove.Show();
            }

            else
            {
                delTMMove.Hide();
            }
        }

        private void btnAddTM_Click(object sender, EventArgs e)
        {
            int MoveNum = 0;
            try
            {
                MoveNum = (int)((PokéDex.Moves)Enum.Parse(typeof(PokéDex.Moves), nudTMMove.Text.Replace("-", "0").Replace(" ", "_"), true));
            }
            catch
            {
                MessageBox.Show("Either this move does not exist or you spelled it wrong");
                return;
            }
            if (lbxTMMoves.Items.Contains(MoveNum) == false)
            {
                lbxTMMoves.Items.Add(MoveNum);
            }
        }

        private void delTMMove_Click(object sender, EventArgs e)
        {
            lbxTMMoves.Items.Remove(lbxTMMoves.SelectedItem);
        }

        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            int MoveNum = 0;
            try
            {
                MoveNum = (int)((PokéDex.Moves)Enum.Parse(typeof(PokéDex.Moves), nudTutorMove.Text.Replace("-", "0").Replace(" ", "_"), true));
            }
            catch
            {
                MessageBox.Show("Either this move does not exist or you spelled it wrong");
                return;
            }
            if (lbxTutorMoves.Items.Contains(MoveNum) == false)
            {
                lbxTutorMoves.Items.Add(MoveNum);
            }
        }

        private void delTutorMove_Click(object sender, EventArgs e)
        {
            lbxTutorMoves.Items.Remove(lbxTutorMoves.SelectedItem);
        }

        private void lbxTutorMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxTutorMoves.SelectedItem != null)
                delTutorMove.Show();
            else
                delTutorMove.Hide();
        }

        bool useNameForAll = false;
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cbxAlolan.Checked)
            {

                int DexNum = (int)(nudDexNum.Value - 7000);

                try
                {
                    Connection.Open();

                    string stm = "SELECT VERSION()";
                    MySqlCommand cmd = new MySqlCommand(stm, Connection);
                    string version = Convert.ToString(cmd.ExecuteScalar());
                    Console.WriteLine("MySQL version : {0}", version);

                }
                catch
                {
                    MessageBox.Show("There was an error with your connection to the SQL server. Please check your internet connection and make sure you entered the info right.");
                    Enabled = true;
                    return;
                }

                int formNum = 7;

                Enabled = false;
                bool shouldReplace = false;
                string PokeInfo = @"INSERT INTO `pokedex_pokemon` (`DexNum`, `PokemonName`, `SpeciesName`, `GrowthGroup`, `EggGroup1`, `EggGroup2`) VALUES (" + DexNum + @", '" + tbName.Text + @"', '" + tbSpecies.Text + @"'," + cbxGrowthGroup.SelectedIndex + @", '" + tbEggGroup1.Text + @"', '" + tbEggGroup2.Text + @"')";
                MySqlCommand addPokedexInfo = new MySqlCommand(PokeInfo, Connection);
                try
                {
                    addPokedexInfo.ExecuteScalar();
                }
                catch
                {
                    if (MessageBox.Show("This Pokémon already exists! Since this is an Alolan Pokémon I recommend you leave the original alone. Stats are located in the next query. Would you still like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        shouldReplace = true;
                        PokeInfo = @"REPLACE INTO `pokedex_pokemon` (`DexNum`, `PokemonName`, `SpeciesName`, `GrowthGroup`, `EggGroup1`, `EggGroup2`) VALUES (" + DexNum + @", '" + tbName.Text + @"', '" + tbSpecies.Text + @"'," + cbxGrowthGroup.SelectedIndex + @", '" + tbEggGroup1.Text + @"', '" + tbEggGroup2.Text + @"')";
                        addPokedexInfo = new MySqlCommand(PokeInfo, Connection);
                        try
                        {
                            addPokedexInfo.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A portion of the data you entered was incorrect. Please check your data. Exception Data: " + ex.StackTrace, "Error");
                            Enabled = true;
                            return;
                        }
                    }
                }
                //If pokedex_appearence is used, this needs added. It seems only pokedex_form is used
                for (int i = 0; i < (int)nudForms.Value; i++)
                {

                }

                //"{" Helps me find EggMoveInfo string in other for statements 
                {
                    string EggMoveInfo = "";
                    shouldReplace = false;
                    for (int i = 0; i < lbxEggMoves.Items.Count; i++)
                    {
                        try
                        {
                            if (shouldReplace)
                            {
                                EggMoveInfo = @"REPLACE INTO `pokedex_pokemoneggmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEggMoves.GetItemText(lbxEggMoves.Items[i]) + @"')";
                                shouldReplace = false;
                            }
                            else
                                EggMoveInfo = @"INSERT INTO `pokedex_pokemoneggmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEggMoves.GetItemText(lbxEggMoves.Items[i]) + @"')";
                            MySqlCommand AddPokeEggMoves = new MySqlCommand(EggMoveInfo, Connection);
                            AddPokeEggMoves.ExecuteScalar();

                        }
                        catch
                        {
                            if (EggMoveInfo.Contains("REPLACE"))
                            {
                                MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                Enabled = true;
                                return;
                            }

                            if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                shouldReplace = true;
                                i--;
                                continue;
                            }

                        }
                    }
                }

                {
                    string EventMoveInfo = "";
                    shouldReplace = false;
                    for (int i = 0; i < lbxEventMoves.Items.Count; i++)
                    {
                        try
                        {
                            if (shouldReplace)
                            {
                                EventMoveInfo = @"REPLACE INTO `pokedex_pokemoneventmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEventMoves.GetItemText(lbxEventMoves.Items[i]) + @"')";
                                shouldReplace = false;
                            }
                            else
                                EventMoveInfo = @"INSERT INTO `pokedex_pokemoneventmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEventMoves.GetItemText(lbxEventMoves.Items[i]) + @"')";
                            MySqlCommand AddPokeEventMoves = new MySqlCommand(EventMoveInfo, Connection);
                            AddPokeEventMoves.ExecuteScalar();

                        }
                        catch
                        {
                            if (EventMoveInfo.Contains("REPLACE"))
                            {
                                MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                Enabled = true;
                                return;
                            }

                            if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                shouldReplace = true;
                                i--;
                                continue;
                            }

                        }
                    }
                }

                {
                    shouldReplace = false;
                    string FormInfo = "";
                    string FormName = "Normal";

                    try
                    {
                        if (shouldReplace)
                        {
                            FormInfo = @"REPLACE INTO `pokedex_pokemonform` (`DexNum`, `FormNum`, `FormName`, `HP`, `Attack`, `Defense`, `SpecialAttack`, `SpecialDefense`, `Speed`, `Male`, `Female`, `Height`, `Weight`, `Type1`, `Type2`, `Ability1`, `Ability2`, `Ability3`, `ExpYield`) VALUES " +
                                @"(" + DexNum + @", '" + formNum + @"', '" + FormName + @"', '" + nudHP.Value + @"', '" + nudATK.Value + @"', '" + nudDef.Value + @"', '" +
                                nudSPATK.Value + @"', '" + nudSPDEF.Value + @"', '" + nudSPEED.Value + @"', '" + nudMaleRatio.Value + @"', '" + nudFemaleRatio.Value + @"', '" + nudHeight.Value + @"', '" +
                                nudWeight.Value + @"', '" + cbxType1.SelectedIndex + @"', '" + cbxType2.SelectedIndex + @"', '" + tbAbility1.Text + @"', '" + tbAbility2.Text + @"', '" + tbAbilityH.Text + @"', '" + nudEXPYield.Value + @"')";
                            shouldReplace = false;
                        }
                        else
                            FormInfo = @"INSERT INTO `pokedex_pokemonform` (`DexNum`, `FormNum`, `FormName`, `HP`, `Attack`, `Defense`, `SpecialAttack`, `SpecialDefense`, `Speed`, `Male`, `Female`, `Height`, `Weight`, `Type1`, `Type2`, `Ability1`, `Ability2`, `Ability3`, `ExpYield`) VALUES " +
                                @"(" + DexNum + @", '" + formNum + @"', '" + FormName + @"', '" + nudHP.Value + @"', '" + nudATK.Value + @"', '" + nudDef.Value + @"', '" +
                                nudSPATK.Value + @"', '" + nudSPDEF.Value + @"', '" + nudSPEED.Value + @"', '" + nudMaleRatio.Value + @"', '" + nudFemaleRatio.Value + @"', '" + nudHeight.Value + @"', '" +
                                nudWeight.Value + @"', '" + cbxType1.SelectedIndex + @"', '" + cbxType2.SelectedIndex + @"', '" + tbAbility1.Text + @"', '" + tbAbility2.Text + @"', '" + tbAbilityH.Text + @"', '" + nudEXPYield.Value + @"')";
                        MySqlCommand AddPokeEventMoves = new MySqlCommand(FormInfo, Connection);
                        AddPokeEventMoves.ExecuteScalar();

                    }
                    catch
                    {
                        if (FormInfo.Contains("REPLACE"))
                        {
                            MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                            Enabled = true;
                            return;
                        }

                        if (MessageBox.Show("This Pokémon already has stats at form: " + formNum + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            shouldReplace = true;
                        }
                    }
                }

                {
                    string LevelMoveInfo = "";
                    shouldReplace = false;
                    for (int i = 0; i < lbxLevelMove.Items.Count; i++)
                    {

                        int LeveltoLearn = 0;
                        using (MoveLevelPrompt prompt = new MoveLevelPrompt(tbName.Text, MySQLInitialization.PokémonData.GetMoveFromIndex(int.Parse(lbxLevelMove.GetItemText(lbxLevelMove.Items[i])), Connection)))
                        {
                            if (prompt.ShowDialog() == DialogResult.OK)
                            {
                                LeveltoLearn = prompt.Result;
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        try
                        {
                            if (shouldReplace)
                            {
                                LevelMoveInfo = @"REPLACE INTO `pokedex_pokemonlevelmove` (`DexNum`, `FormNum`, `MoveIndex`, `LevelNum`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + LeveltoLearn + @"', '" + lbxLevelMove.GetItemText(lbxLevelMove.Items[i]) + @"')";
                                shouldReplace = false;
                            }
                            else
                            {
                                LevelMoveInfo = @"INSERT INTO `pokedex_pokemonlevelmove` (`DexNum`, `FormNum`, `MoveIndex`, `LevelNum`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + LeveltoLearn + @"', '" + lbxLevelMove.GetItemText(lbxLevelMove.Items[i]) + @"')";
                            }

                            MySqlCommand AddPokeEventMoves = new MySqlCommand(LevelMoveInfo, Connection);
                            AddPokeEventMoves.ExecuteScalar();

                        }
                        catch
                        {
                            if (LevelMoveInfo.Contains("REPLACE"))
                            {
                                MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                Enabled = true;
                                return;
                            }

                            if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                shouldReplace = true;
                                i--;
                            }

                        }
                    }
                }

                {
                    string TMMoveInfo = "";
                    shouldReplace = false;
                    for (int i = 0; i < lbxTMMoves.Items.Count; i++)
                    {
                        try
                        {
                            if (shouldReplace)
                            {
                                TMMoveInfo = @"REPLACE INTO `pokedex_pokemontmmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTMMoves.GetItemText(lbxTMMoves.Items[i]) + @"')";
                                shouldReplace = false;
                            }
                            else
                                TMMoveInfo = @"INSERT INTO `pokedex_pokemontmmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTMMoves.GetItemText(lbxTMMoves.Items[i]) + @"')";
                            MySqlCommand AddPokeEventMoves = new MySqlCommand(TMMoveInfo, Connection);
                            AddPokeEventMoves.ExecuteScalar();

                        }
                        catch
                        {
                            if (TMMoveInfo.Contains("REPLACE"))
                            {
                                MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                Enabled = true;
                                return;
                            }

                            if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                shouldReplace = true;
                                i--;
                                continue;
                            }

                        }
                    }
                }

                {
                    string TutorMoveInfo = "";
                    shouldReplace = false;
                    for (int i = 0; i < lbxEventMoves.Items.Count; i++)
                    {
                        try
                        {
                            if (shouldReplace)
                            {
                                TutorMoveInfo = @"REPLACE INTO `pokedex_pokemontutormove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTutorMoves.GetItemText(lbxTutorMoves.Items[i]) + @"')";
                                shouldReplace = false;
                            }
                            else
                                TutorMoveInfo = @"INSERT INTO `pokedex_pokemontutormove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTutorMoves.GetItemText(lbxTutorMoves.Items[i]) + @"')";
                            MySqlCommand AddPokeEventMoves = new MySqlCommand(TutorMoveInfo, Connection);
                            AddPokeEventMoves.ExecuteScalar();

                        }
                        catch
                        {
                            if (TutorMoveInfo.Contains("REPLACE"))
                            {
                                MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                Enabled = true;
                                return;
                            }

                            if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                shouldReplace = true;
                                i--;
                                continue;
                            }

                        }
                    }
                }

                Connection.Close();
                Enabled = true;
            }

            else
            {

                int DexNum = (int)(nudDexNum.Value);

                try
                {
                    Connection.Open();

                    string stm = "SELECT VERSION()";
                    MySqlCommand cmd = new MySqlCommand(stm, Connection);
                    string version = Convert.ToString(cmd.ExecuteScalar());
                    Console.WriteLine("MySQL version : {0}", version);

                }
                catch
                {
                    MessageBox.Show("There was an error with your connection to the SQL server. Please check your internet connection and make sure you entered the info right.");
                    return;
                }

                Enabled = false;
                bool shouldReplace = false;
                string PokeInfo = @"INSERT INTO `pokedex_pokemon` (`DexNum`, `PokemonName`, `SpeciesName`, `GrowthGroup`, `EggGroup1`, `EggGroup2`) VALUES (" + DexNum + @", '" + tbName.Text + @"', '" + tbSpecies.Text + @"'," + cbxGrowthGroup.SelectedIndex + @", '" + tbEggGroup1.Text + @"', '" + tbEggGroup2.Text + @"')";
                MySqlCommand addPokedexInfo = new MySqlCommand(PokeInfo, Connection);
                try
                {
                    addPokedexInfo.ExecuteScalar();
                }
                catch
                {
                    if (MessageBox.Show("This Pokémon already exists! Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        shouldReplace = true;
                        PokeInfo = @"REPLACE INTO `pokedex_pokemon` (`DexNum`, `PokemonName`, `SpeciesName`, `GrowthGroup`, `EggGroup1`, `EggGroup2`) VALUES (" + DexNum + @", '" + tbName.Text + @"', '" + tbSpecies.Text + @"'," + cbxGrowthGroup.SelectedIndex + @", '" + tbEggGroup1.Text + @"', '" + tbEggGroup2.Text + @"')";
                        addPokedexInfo = new MySqlCommand(PokeInfo, Connection);
                        try
                        {
                            addPokedexInfo.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A portion of the data you entered was incorrect. Please check your data. Exception Data: " + ex.StackTrace, "Error");
                            Enabled = true;
                            return;
                        }
                    }
                }
                //If pokedex_appearence is used, this needs added. It seems only pokedex_form is used
                for (int i = 0; i < (int)nudForms.Value; i++)
                {

                }

                //"{" Helps me find EggMoveInfo string in other for statements 
                {
                    string EggMoveInfo = "";
                    shouldReplace = false;
                    for (int formNum = 0; formNum < nudForms.Value; formNum++)
                    {
                        for (int i = 0; i < lbxEggMoves.Items.Count; i++)
                        {
                            try
                            {
                                if (shouldReplace)
                                {
                                    EggMoveInfo = @"REPLACE INTO `pokedex_pokemoneggmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEggMoves.GetItemText(lbxEggMoves.Items[i]) + @"')";
                                    shouldReplace = false;
                                }
                                else
                                    EggMoveInfo = @"INSERT INTO `pokedex_pokemoneggmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEggMoves.GetItemText(lbxEggMoves.Items[i]) + @"')";
                                MySqlCommand AddPokeEggMoves = new MySqlCommand(EggMoveInfo, Connection);
                                AddPokeEggMoves.ExecuteScalar();

                            }
                            catch
                            {
                                if (EggMoveInfo.Contains("REPLACE"))
                                {
                                    MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                    Enabled = true;
                                    return;
                                }

                                if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    shouldReplace = true;
                                    i--;
                                    continue;
                                }

                            }
                        }
                    }
                }

                {
                    string EventMoveInfo = "";
                    shouldReplace = false;
                    for (int formNum = 0; formNum < nudForms.Value; formNum++)
                    {
                        for (int i = 0; i < lbxEventMoves.Items.Count; i++)
                        {
                            try
                            {
                                if (shouldReplace)
                                {
                                    EventMoveInfo = @"REPLACE INTO `pokedex_pokemoneventmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEventMoves.GetItemText(lbxEventMoves.Items[i]) + @"')";
                                    shouldReplace = false;
                                }
                                else
                                    EventMoveInfo = @"INSERT INTO `pokedex_pokemoneventmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxEventMoves.GetItemText(lbxEventMoves.Items[i]) + @"')";
                                MySqlCommand AddPokeEventMoves = new MySqlCommand(EventMoveInfo, Connection);
                                AddPokeEventMoves.ExecuteScalar();

                            }
                            catch
                            {
                                if (EventMoveInfo.Contains("REPLACE"))
                                {
                                    MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                    Enabled = true;
                                    return;
                                }

                                if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    shouldReplace = true;
                                    i--;
                                    continue;
                                }

                            }
                        }
                    }
                }

                shouldReplace = false;
                string FormInfo = "";
                string FormName = "Normal";
                for (int formNum = 0; formNum < nudForms.Value; formNum++)
                {
                    if (!useNameForAll)
                    {
                        using (FormNamePrompt prompt = new FormNamePrompt(formNum))
                        {
                            if (prompt.ShowDialog() == DialogResult.OK)
                            {
                                FormName = prompt.Result;
                                useNameForAll = prompt.useForAll;
                            }
                            else
                            {
                                formNum--;
                                continue;
                            }
                        }
                    }

                    try
                    {
                        if (shouldReplace)
                        {
                            FormInfo = @"REPLACE INTO `pokedex_pokemonform` (`DexNum`, `FormNum`, `FormName`, `HP`, `Attack`, `Defense`, `SpecialAttack`, `SpecialDefense`, `Speed`, `Male`, `Female`, `Height`, `Weight`, `Type1`, `Type2`, `Ability1`, `Ability2`, `Ability3`, `ExpYield`) VALUES " +
                                @"(" + DexNum + @", '" + formNum + @"', '" + FormName + @"', '" + nudHP.Value + @"', '" + nudATK.Value + @"', '" + nudDef.Value + @"', '" +
                                nudSPATK.Value + @"', '" + nudSPDEF.Value + @"', '" + nudSPEED.Value + @"', '" + nudMaleRatio.Value + @"', '" + nudFemaleRatio.Value + @"', '" + nudHeight.Value + @"', '" +
                                nudWeight.Value + @"', '" + cbxType1.SelectedIndex + @"', '" + cbxType2.SelectedIndex + @"', '" + tbAbility1.Text + @"', '" + tbAbility2.Text + @"', '" + tbAbilityH.Text + @"', '" + nudEXPYield.Value + @"')";
                            shouldReplace = false;
                        }
                        else
                            FormInfo = @"INSERT INTO `pokedex_pokemonform` (`DexNum`, `FormNum`, `FormName`, `HP`, `Attack`, `Defense`, `SpecialAttack`, `SpecialDefense`, `Speed`, `Male`, `Female`, `Height`, `Weight`, `Type1`, `Type2`, `Ability1`, `Ability2`, `Ability3`, `ExpYield`) VALUES " +
                                @"(" + DexNum + @", '" + formNum + @"', '" + FormName + @"', '" + nudHP.Value + @"', '" + nudATK.Value + @"', '" + nudDef.Value + @"', '" +
                                nudSPATK.Value + @"', '" + nudSPDEF.Value + @"', '" + nudSPEED.Value + @"', '" + nudMaleRatio.Value + @"', '" + nudFemaleRatio.Value + @"', '" + nudHeight.Value + @"', '" +
                                nudWeight.Value + @"', '" + cbxType1.SelectedIndex + @"', '" + cbxType2.SelectedIndex + @"', '" + tbAbility1.Text + @"', '" + tbAbility2.Text + @"', '" + tbAbilityH.Text + @"', '" + nudEXPYield.Value + @"')";
                        MySqlCommand AddPokeEventMoves = new MySqlCommand(FormInfo, Connection);
                        AddPokeEventMoves.ExecuteScalar();

                    }
                    catch
                    {
                        if (FormInfo.Contains("REPLACE"))
                        {
                            MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                            Enabled = true;
                            return;
                        }

                        if (MessageBox.Show("This Pokémon already has stats at form: " + formNum + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            shouldReplace = true;
                            formNum--;
                            continue;
                        }

                    }
                }

                {
                    string LevelMoveInfo = "";
                    shouldReplace = false;
                    for (int formNum = 0; formNum < nudForms.Value; formNum++)
                    {
                        for (int i = 0; i < lbxLevelMove.Items.Count; i++)
                        {

                            int LeveltoLearn = 0;
                            using (MoveLevelPrompt prompt = new MoveLevelPrompt(tbName.Text, MySQLInitialization.PokémonData.GetMoveFromIndex(int.Parse(lbxLevelMove.GetItemText(lbxLevelMove.Items[i])), Connection)))
                            {
                                if (prompt.ShowDialog() == DialogResult.OK)
                                {
                                    LeveltoLearn = prompt.Result;
                                }
                                else
                                {
                                    i--;
                                    continue;
                                }
                            }
                            try
                            {
                                if (shouldReplace)
                                {
                                    LevelMoveInfo = @"REPLACE INTO `pokedex_pokemonlevelmove` (`DexNum`, `FormNum`, `MoveIndex`, `LevelNum`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + LeveltoLearn + @"', '" + lbxLevelMove.GetItemText(lbxLevelMove.Items[i]) + @"')";
                                    shouldReplace = false;
                                }
                                else
                                {
                                    LevelMoveInfo = @"INSERT INTO `pokedex_pokemonlevelmove` (`DexNum`, `FormNum`, `MoveIndex`, `LevelNum`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + LeveltoLearn + @"', '" + lbxLevelMove.GetItemText(lbxLevelMove.Items[i]) + @"')";
                                }

                                MySqlCommand AddPokeEventMoves = new MySqlCommand(LevelMoveInfo, Connection);
                                AddPokeEventMoves.ExecuteScalar();

                            }
                            catch
                            {
                                if (LevelMoveInfo.Contains("REPLACE"))
                                {
                                    MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                    Enabled = true;
                                    return;
                                }

                                if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    shouldReplace = true;
                                    i--;
                                }

                            }
                        }
                    }
                }

                {
                    string TMMoveInfo = "";
                    shouldReplace = false;
                    for (int formNum = 0; formNum < nudForms.Value; formNum++)
                    {
                        for (int i = 0; i < lbxTMMoves.Items.Count; i++)
                        {
                            try
                            {
                                if (shouldReplace)
                                {
                                    TMMoveInfo = @"REPLACE INTO `pokedex_pokemontmmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTMMoves.GetItemText(lbxTMMoves.Items[i]) + @"')";
                                    shouldReplace = false;
                                }
                                else
                                    TMMoveInfo = @"INSERT INTO `pokedex_pokemontmmove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTMMoves.GetItemText(lbxTMMoves.Items[i]) + @"')";
                                MySqlCommand AddPokeEventMoves = new MySqlCommand(TMMoveInfo, Connection);
                                AddPokeEventMoves.ExecuteScalar();

                            }
                            catch
                            {
                                if (TMMoveInfo.Contains("REPLACE"))
                                {
                                    MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                    Enabled = true;
                                    return;
                                }

                                if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    shouldReplace = true;
                                    i--;
                                    continue;
                                }

                            }
                        }
                    }
                }

                {
                    string TutorMoveInfo = "";
                    shouldReplace = false;
                    for (int formNum = 0; formNum < nudForms.Value; formNum++)
                    {
                        for (int i = 0; i < lbxEventMoves.Items.Count; i++)
                        {
                            try
                            {
                                if (shouldReplace)
                                {
                                    TutorMoveInfo = @"REPLACE INTO `pokedex_pokemontutormove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTutorMoves.GetItemText(lbxTutorMoves.Items[i]) + @"')";
                                    shouldReplace = false;
                                }
                                else
                                    TutorMoveInfo = @"INSERT INTO `pokedex_pokemontutormove` (`DexNum`, `FormNum`, `MoveIndex`, `Move`) VALUES (" + DexNum + @", '" + formNum + @"', '" + i + @"', '" + lbxTutorMoves.GetItemText(lbxTutorMoves.Items[i]) + @"')";
                                MySqlCommand AddPokeEventMoves = new MySqlCommand(TutorMoveInfo, Connection);
                                AddPokeEventMoves.ExecuteScalar();

                            }
                            catch
                            {
                                if (TutorMoveInfo.Contains("REPLACE"))
                                {
                                    MessageBox.Show("A portion of the data you entered was incorrect. Please check your data.", "Error");
                                    Enabled = true;
                                    return;
                                }

                                if (MessageBox.Show("This Pokémon already has a move at index: " + i + ". Would you like to replace it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    shouldReplace = true;
                                    i--;
                                    continue;
                                }

                            }
                        }
                    }
                }

                Connection.Close();
                Enabled = true;


            }
        }



    }
}
