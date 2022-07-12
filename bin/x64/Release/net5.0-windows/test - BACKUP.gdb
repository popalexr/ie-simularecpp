# http://sourceware.org/gdb/wiki/FAQ: to disable the
# "---Type <return> to continue, or q <return> to quit---"
# in batch mode:
#set width 0
#set height 0
#set verbose off

# at entry point - cmd1
b main
commands 1
    set $start = 1
    while($start<100)
        step
        info locals
        set $start = $start + 1
    end
end

# note: even if arguments are shown;
# must specify cmdline arg for "run"
# when running in batch mode! (then they are ignored)
# below, we specify command line argument "2":
run 1

#start # alternative to run: runs to main, and stops
#continue
print ("You can exit safe.")
quit