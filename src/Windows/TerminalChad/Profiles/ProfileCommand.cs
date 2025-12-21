
namespace TerminalChad.Profiles;
public class ProfileCommand {
    /* === Intentions Of Profile Command ===
     * 
     * - Have users be able to create a profile which contains:
     *      - Themes
     *      - Applications To Install
     *      - Scripts Which They Can Run
     * 
     * === USAGE ===
     * 
     * terminalchad profile -n          Creates a new profile
     * terminalchad profile -u          Enables a profile which already exists
     * terminalchad profile -d          Downloads profile(s) from a zipball url
     * terminalchad profile -m [PROFILE_NAME] -x    Deletes profile
     * terminalchad profile -m [PROFILE_NAME] -r    Renames a profile
     * terminalchad prfiles -m [PROFILE_NAME] -w    Gets path of the profile
     * terminalchad profile -m [PROFILE_NAME] -c [SETTING_NAME] [NEW_VALUE] Changes value of a profile setting
     * terminalchad profile -m [PROFILE_NAME] -b    Reopens the profile builder
     */

    // This will need to be written in C++. I hate c#. 

    public void Parse(string[] args) {

    }
}
