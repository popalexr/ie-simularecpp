b main
commands 1
    set $start = 1
    while($start<2000)
        step
        set $start = $start + 1
    end
end

run 1

quit