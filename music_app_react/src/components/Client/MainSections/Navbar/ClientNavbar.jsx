import mainLogo from "@/assets/icons/mainLogo.png";
import {
  AppBar,
  Toolbar,
  Grid,
  Tabs,
  Tab,
  Box,
  Button,
  useTheme,
  useMediaQuery,
  Typography,
  Menu,
  MenuItem,
  IconButton,
} from "@mui/material";
import { useState } from "react";
import { NavLink } from "react-router-dom";
import clientRoutes from "@/routing/ClientRoutes";
import styles from "./ClientNavbar.module.scss";
import LoginIcon from "@mui/icons-material/Login";
import AppRegistrationIcon from "@mui/icons-material/AppRegistration";
import Sidebar from "./Sidebar";
import authRoutes from "@/routing/authRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import { useNavigate } from "react-router-dom";
import useAuth from "@/utils/useAuth";
import Logout from "@/components/Auth/Logout/Logout";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown";
import ArrowDropUpIcon from "@mui/icons-material/ArrowDropUp";
import PersonPinIcon from "@mui/icons-material/PersonPin";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";
import LogoutIcon from "@mui/icons-material/Logout";

function ClientNavbar() {
  const { user } = useAuth(); // Use the useAuth() to retrieve the user
  const theme = useTheme();
  const isMatch = useMediaQuery(theme.breakpoints.down("md"));
  const [value, setValue] = useState(0);
  const routes = clientRoutes[0].children.filter(route => route.label !== 'Account');
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = useState(null);

  const handleMenuOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
  };

  return (
    <AppBar className={styles.navbar}>
      <Toolbar>
        {isMatch ? (
          <>
            {" "}
            <img
              src={mainLogo}
              style={{ width: "100px", display: "block", marginRight: "auto" }}
              alt="Main Logo"
            ></img>
            <Sidebar />
          </>
        ) : (
          <Grid container sx={{ placeItems: "center" }}>
            <Grid item xs={2}>
              <img
                src={mainLogo}
                style={{ width: "100px", display: "block", margin: "auto" }}
                alt="Main Logo"
              ></img>
            </Grid>
            <Grid item xs={6}>
              <Tabs
                textColor="inherit"
                indicatorColor="secondary"
                value={value}
                onChange={(e, val) => setValue(val)}
              >
                {routes.map((route, index) => (
                  <Tab
                    key={index}
                    label={route.label}
                    component={NavLink}
                    to={route.path}
                  />
                ))}
              </Tabs>
            </Grid>
            <Grid item xs={1} />
            <Grid item xs={3}>
              <Box display="flex" gap={1} alignItems="center">
                {user ? (
                  <>
                    {/* Separated "Welcome" text */}
                    <Typography
                      style={{
                        color: "#a096bf",
                        fontWeight: "bold",
                        fontSize: "1rem",
                      }}
                    >
                      Welcome,
                    </Typography>

                    {/* Firstname + Lastname as the menu header */}
                    <Button
                      style={{
                        color: "#a096bf",
                        fontWeight: "bold",
                        fontSize: "1rem",
                      }}
                      onClick={handleMenuOpen}
                    >
                      {`${user.firstname} ${user.lastname}`}
                      {/* Arrow icon indicating the menu can be toggled */}
                      {anchorEl ? <ArrowDropUpIcon /> : <ArrowDropDownIcon />}
                    </Button>

                    {/* Menu */}
                    <Menu
                      anchorEl={anchorEl}
                      open={Boolean(anchorEl)}
                      onClose={handleMenuClose}
                      PaperProps={{
                        sx: {
                          backgroundColor: "#9370DB",
                          borderRadius: "8px",
                          boxShadow: "0px 3px 10px rgba(0, 0, 0, 0.2)",
                        },
                      }}
                    >
                      {/* Menu Items */}
                      <MenuItem
                        sx={{ "&:hover": { backgroundColor: "#D8BFD8" } }}
                        onClick={() => navigate(findPathByLabel(clientRoutes, "Profile"))}
                      >
                        <PersonPinIcon style={{ marginRight: "0.5rem" }} />
                        Profile
                      </MenuItem>
                      <MenuItem
                        sx={{ "&:hover": { backgroundColor: "#D8BFD8" } }}
                        onClick={() => navigate(findPathByLabel(clientRoutes, "Account"))}
                      >
                        <ManageAccountsIcon style={{ marginRight: "0.5rem" }} />
                        My Account
                      </MenuItem>
                      <MenuItem
                        sx={{ "&:hover": { backgroundColor: "#D8BFD8" } }}
                      >
                        <LogoutIcon style={{ marginRight: "0.1rem" }} />
                        <Logout>
                          <Typography
                            style={{
                              fontWeight: "normal",
                              fontSize: "1rem",
                            }}
                          >
                            Logout
                          </Typography>
                        </Logout>
                      </MenuItem>
                    </Menu>
                  </>
                ) : (
                  // Show login and signup buttons if user is not authenticated
                  <>
                    <Button
                      variant="outlined"
                      sx={{ marginLeft: "auto" }}
                      className={styles.outlinedButton}
                      startIcon={<LoginIcon />}
                      onClick={() =>
                        navigate(findPathByLabel(authRoutes, "SignIn"))
                      }
                    >
                      SignIn
                    </Button>
                    <Button
                      variant="outlined"
                      className={styles.outlinedButton}
                      startIcon={<AppRegistrationIcon />}
                      onClick={() =>
                        navigate(findPathByLabel(authRoutes, "SignUp"))
                      }
                    >
                      Signup
                    </Button>
                  </>
                )}
              </Box>
            </Grid>
          </Grid>
        )}
      </Toolbar>
    </AppBar>
  );
}

export default ClientNavbar;
